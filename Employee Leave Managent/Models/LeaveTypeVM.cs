using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Leave_Managent.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "الإسم")]
        public string Name { get; set; }
        [Required]
        [Display(Name="العدد الافتراضي من الايام")]
        [Range(1,30, ErrorMessage ="اقصى رصيد سنوي هو 30 يوم")]
        public int DefaultDays { get; set; }
        [Display(Name ="تاريخ الانشاء")]
        public DateTime? DateCreated { get; set; }
    }   
}
