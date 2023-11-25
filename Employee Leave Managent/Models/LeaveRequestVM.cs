using Employee_Leave_Managent.Models.CustomValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Leave_Managent.Models
{
    public class LeaveRequestVM
    {
        public int Id { get; set; }
        [Display(Name = " طلب موظف ")]
        public EmployeeVM RequestingEmployee { get; set; }
        [Display (Name = "اسم الموظف ")]

        public string RequestingEmployeeId { get; set; }
        [Display(Name = " من تاريخ")]
        [Required]
        [DataType(DataType.Date)]
        //[CustomDateValidation(ErrorMessage = "يجب أن يكون التاريخ أقل من تاريخ اليوم بيوم واحد على الأقل.")]
        public DateTime StartDate { get; set; }
        [Display(Name = "الى تاريخ")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Display(Name = "نوع الإجازة ")]
        public LeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        [Display(Name = "تاريخ الطلب")]
        public DateTime DateRequested { get; set; }
        [Display(Name = "تاريخ الاجراء")]
        public DateTime DateActioned { get; set; }
        [Display(Name = "حالة القبول")]
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public EmployeeVM ApprovedBy { get; set; }
        [Display(Name = "اسم المسؤول")]
        public string ApprovedById { get; set; }
        [Display(Name ="تعليق الموظف")]
        [MaxLength(300)]
        public string RequestComments { get; set; }
    }

    public class AdminLeaveRequestViewVM
    {
        [Display(Name = "اجمالي عدد الطلبات" )]
        public int TotalRequests { get; set; }
        [Display(Name = "الطلبات المقبولة")]
        public int ApprovedRequests { get; set; }
        [Display(Name = "الطلبات المعلقة")]
        public int PendingRequests { get; set; }
        [Display(Name = "الطلبات المرفوظه")]
        public int RejectedRequests { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }

    public class CreateLeaveRequestVM
    {
        [Display(Name = "من تاريخ")]
        [Required]
        public string StartDate { get; set; }
        [Display(Name = "الى تاريخ")]
        [Required]
        public string EndDate { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
        [Display(Name ="نوع الاجازة")]
        public int LeaveTypeId { get; set; }
       /*// public IEnumerable<SelectListItem> Employees { get; set; }
        [Display(Name = "للموظف : ")]
        public string EmployeeId { get; set; }*/
        [Display(Name = "تعليق الموظف")]
        [MaxLength(300)]
        public string RequestComments { get; set; }

    }

    public class EmployeeLeaveRequestViewVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
