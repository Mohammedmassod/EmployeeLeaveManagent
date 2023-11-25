using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Employee_Leave_Managent.Data.Migrations
{
    public class Employee : IdentityUser
    {
        [Display(Name = "الاسم الاول")]
        public string Firstname { get; set; }
        [Display(Name = "إسم العائلة")]

        public string Lastname { get; set; }
        [Display(Name = "الرقم الوظيفي ")]
        public string TaxId { get; set; }
        [Display(Name = "تاريخ الميلاد ")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "تاريخ التوظيف")]
        public DateTime DateJoined { get; set; }
    }
}
