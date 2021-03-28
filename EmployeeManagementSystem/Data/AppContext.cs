using EmployeeManagementSystem.EntityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<AttendanceDetail> AttendanceDetail { get; set; }
        public DbSet<CompanyInformation> CompanyInformation { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<LeaveApplication> LeaveApplication { get; set; }
        public DbSet<LeaveType> LeaveType { get; set; }
        public DbSet<SalaryStructure> SalaryStructure { get; set; }
    }
}
