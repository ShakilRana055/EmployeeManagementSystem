using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.EntityModel
{
    public class Employee:BaseClass
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public string BirthDate { get; set; }
        public string JoiningDate { get; set; }
        public string NID { get; set; }
        public string NIDUrl { get; set; }
        public string PhotoUrl { get; set; }
        public string BirthCertificateUrl { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
    }
    public enum EmployeeStatus
    {
        Loading = 1,
        Active = 2,
        Deactive = 3,
        New = 4,
        Old = 5,
        Resigned = 6,
    }
}
