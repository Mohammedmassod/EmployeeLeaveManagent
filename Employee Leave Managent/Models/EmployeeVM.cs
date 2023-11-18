using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Employee_Leave_Managent.Models
{
    public class EmployeeVM
    {
        public string Id { get; set; }
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }
        [Display(Name = "الإيميل ")]
        public string Email { get; set; }
        [Display(Name = "رقم التلفون ")]
        public string PhoneNumber { get; set; }
        [Display(Name = "الإسم الأول ")]
        public string Firstname { get; set; }
        [Display(Name = "إسم العائلة ")]
        public string Lastname { get; set; }
        [Display(Name = "الرقم الوظيفي ")]
        public string TaxId { get; set; }
        [Display(Name = "تاريخ الميلاد ")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "تاريخ التوظيف ")]
        public DateTime DateJoined { get; set; }
    }
}
