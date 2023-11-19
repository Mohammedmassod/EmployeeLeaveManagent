using Employee_Leave_Managent.Data.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Employee_Leave_Managent.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;
namespace Employee_Leave_Managent.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            var hasher = new PasswordHasher<Employee>();
            builder.Entity<Employee>().HasData(new Employee()
            {
                Id = "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
                Firstname = "mohammed",
                Lastname = "massowd",
                UserName = "admin@mohammed.com",
                Email = "admin@mohammed.com",
                PhoneNumber = "778877887",
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                NormalizedUserName = "ADMIN@MOHAMMED.COM",
                NormalizedEmail = "ADMIN@MOHAMMED.COM",
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = "e420ab41-8204-4604-a5bd-ca77e88def9c",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"

            }, new IdentityRole()
            {
                Id = "2d5ef183-2290-4248-8b9c-b2b3486fa99b",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "e420ab41-8204-4604-a5bd-ca77e88def9c",
                UserId = "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
            });


          base.OnModelCreating(builder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        

    }
}
