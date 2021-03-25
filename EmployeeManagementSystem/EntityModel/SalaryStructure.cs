using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.EntityModel
{
    public class SalaryStructure:BaseClass
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int? EmployeeIdPk { get; set; }
        public Employee Employee { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal HomeRent { get; set; }
        public decimal MobileAllowance { get; set; }
    }
}
