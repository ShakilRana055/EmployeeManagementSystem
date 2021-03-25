using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.EntityModel
{
    public class CompanyInformation:BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string LogoUrl { get; set; }
        public string Slogan { get; set; }
        public string PasswordForAll { get; set; }
        public string OfficeStartTime { get; set; }
        public string OfficeEndTime { get; set; }
        public string OfficeHour { get; set; }
        public string WeeklyHoliday { get; set; }
        public CompanyStatus CompanyStatus { get; set; }
    }
    public enum CompanyStatus
    {
        Active = 1,
        Inactive = 2,
    }
}
