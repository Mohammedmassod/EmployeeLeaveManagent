﻿using AutoMapper;
using Employee_Leave_Managent.Interfaces;
using Employee_Leave_Managent.Data;
using Employee_Leave_Managent.Models;
using Employee_Leave_Managent.Data.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Employee_Leave_Managent.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        //#Liskov
        private readonly ILeaveTypeRepository _leaveRepo;
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        private readonly ApplicationDbContext _context;


        public LeaveAllocationController(
            ILeaveTypeRepository leaveRepo,
            ILeaveAllocationRepository leaveAllocationRepo,
            IMapper mapper,
            UserManager<Employee> userManager
        )
        {
            _leaveRepo = leaveRepo;
            _leaveAllocationRepo = leaveAllocationRepo;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: LeaveAllocationController
        public ActionResult Index()
        {
            var leavetypes = _leaveRepo.FindAll().ToList();
            var mappedLeaveTypes = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leavetypes);
            var model = new CreateLeaveAllocationVM
            {
                LeaveTypes = mappedLeaveTypes,
                NumberUpdated = 0
            };
            return View(model);
        }
        // عرض نموذج الإضافة
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // إنشاء الاحتياط الجديد
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveAllocation leaveAllocation)
        {
            if (ModelState.IsValid)
            {
                _context.LeaveAllocations.Add(leaveAllocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveAllocation);
        }

        /*public ActionResult SetLeave(int id)
        {
            var leaveType = _leaveRepo.FindById(id);
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
            foreach (var emp in employees)
            {
                if (_leaveAllocationRepo.CheckAllocation(id, emp.Id))
                {
                    ModelState.AddModelError("", $"تم تخصيص إجازة {leaveType.Name} للموظف {emp.Firstname} {emp.Lastname} مسبقاً.");
                    continue;
                }
                var allocation = new LeaveAllocationVM
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = emp.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year
                };
                //#Liskov
                var leaveallocation = _mapper.Map<LeaveAllocation>(allocation);
                _leaveAllocationRepo.Create(leaveallocation);
            }
            return RedirectToAction(nameof(Index));
        }*/
        public async Task<ActionResult> SetLeave(int id)
        {
            var leaveType = _leaveRepo.FindById(id);
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;

            // Get the ID of the logged-in employee
            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Add the logged-in employee to the list of employees
            employees.Add(await _userManager.FindByIdAsync(loggedInUserId));

            foreach (var emp in employees)
            {
                if (_leaveAllocationRepo.CheckAllocation(id, emp.Id))
                {
                    ModelState.AddModelError("", $"تم تخصيص إجازة {leaveType.Name} للموظف {emp.Firstname} {emp.Lastname} مسبقاً.");
                    continue;
                }

                var allocation = new LeaveAllocationVM
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = emp.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year
                };

                var leaveallocation = _mapper.Map<LeaveAllocation>(allocation);
                _leaveAllocationRepo.Create(leaveallocation);
            }

            return RedirectToAction(nameof(Index));
        }

        /* public ActionResult ListEmployees()
         {
             var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
             var model = _mapper.Map<List<EmployeeVM>>(employees);

             return View(model);
         }*/
        /* public ActionResult ListEmployees()
         {
             var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
             var currentUser = _userManager.GetUserAsync(User).Result;

             // إضافة الموظف الحالي إلى القائمة إذا لم يتم عرضه بالفعل
             if (!employees.Contains(currentUser))
             {
                 employees.Add(currentUser);
             }

             var model = _mapper.Map<List<EmployeeVM>>(employees);
             return View(model);
         }*/

        // GET: LeaveAllocationController/Details/5
        public ActionResult Details(string id)
        {
            var employee = _mapper.Map<EmployeeVM>(_userManager.FindByIdAsync(id).Result);
            var allocations = _mapper.Map<List<LeaveAllocationVM>>
                (_leaveAllocationRepo.GetLeaveAllocationsByEmployee(id));
            var model = new ViewLeaveAllocationVM
            {
                Employee = employee,
                LeaveAllocations = allocations
            };
            return View(model);
        }   

        // GET: LeaveAllocationController/Create
       /* public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: LeaveAllocationController/Edit/5
        public ActionResult Edit(int id)
        {
            var leaveAllocation = _leaveAllocationRepo.FindById(id);
            var model = _mapper.Map<EditLeaveAllocationVM>(leaveAllocation);
            return View(model);
        }

        // POST: LeaveAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditLeaveAllocationVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var record = _leaveAllocationRepo.FindById(model.Id);
                record.NumberOfDays = model.NumberOfDays;
                var isSuccess = _leaveAllocationRepo.Update(record);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error while savng");
                    return View(model);
                }
                return RedirectToAction(nameof(Details), new {id = model.EmployeeId});
            }
            catch
            {
                return View(model);
            }
        }

        // GET: LeaveAllocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
