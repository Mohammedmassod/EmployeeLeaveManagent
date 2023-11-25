using Employee_Leave_Managent.Data.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Leave_Managent.Data
{
    public class LeaveAllocation
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "عدد الايام ")]
        public int NumberOfDays { get; set; }
        [Display(Name = "تاريخ الإنشاء ")]
        public DateTime DateCreated { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [Display(Name = "رقم الموظف ")]
        public string EmployeeId { get; set; }
        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        [Display(Name = "رقم نوع الاجازة")]
        public int LeaveTypeId { get; set; }
        [Display(Name = " فترة ")]
        public int Period { get; set; }
    }
}
