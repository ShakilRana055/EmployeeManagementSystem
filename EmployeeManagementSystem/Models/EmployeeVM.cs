using EmployeeManagementSystem.EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            SalaryStructures = new List<SalaryStructureVM>();
        }
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public string BirthDate { get; set; }
        public string JoiningDate { get; set; }
        public string NID { get; set; }
        public string NIDUrl { get; set; }
        public string PhotoUrl { get; set; }
        public string BirthCertificateUrl { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public IFormFile NIDPhoto { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile BirthCertificate { get; set; }
        public List<SelectListItem> Department { get; set; }
        public int DepartmentId { get; set; }
        public SalaryStructureVM SalaryStructure { get; set; }
        public List<SalaryStructureVM> SalaryStructures { get; set; }
    }
}
