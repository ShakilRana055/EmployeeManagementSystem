using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.EntityModel
{
    public class LeaveType:BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int NumberOfHolidays { get; set; }
    }
}
