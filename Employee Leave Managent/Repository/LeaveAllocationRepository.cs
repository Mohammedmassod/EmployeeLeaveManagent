﻿using Employee_Leave_Managent.Interfaces;
using Employee_Leave_Managent.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Leave_Managent.Repository
{
    //#Interface Segregation Principle 1
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CheckAllocation(int leavetypeid, string employeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(q => q.EmployeeId == employeeid && q.LeaveTypeId == leavetypeid && q.Period == period)
                .Any();
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var LeaveAllocations = _db.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .ToList();
            return LeaveAllocations;
        }

        public LeaveAllocation FindById(int id)
        {
            var LeaveAllocation = _db.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .FirstOrDefault(q => q.Id == id);
            return LeaveAllocation;
        }

        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string employeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(q => q.EmployeeId == employeeid && q.Period == period)
                .ToList();
        }

        public LeaveAllocation GetLeaveAllocationsByEmployeeAndType(string employeeid, int leavetypeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .FirstOrDefault(q => q.EmployeeId == employeeid && q.Period == period && q.LeaveTypeId == leavetypeid);
        }

        public bool isExists(int id)
        {
            var exist = _db.LeaveAllocations.Any(q => q.Id == id);
            return exist;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
