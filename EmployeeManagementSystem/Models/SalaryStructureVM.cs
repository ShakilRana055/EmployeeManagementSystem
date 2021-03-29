using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class SalaryStructureVM
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal BasicSalary { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal GrossSalary { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal HomeRent { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal MobileAllowance { get; set; }
    }
}
