using EmployeeManagementSystem.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.RepositoryPattern.Interface.GeneralInterface
{
    public interface IEmployeeRepository: IBaseRepository<Employee>
    {
        public Employee GetLastEmployee(string departmentCode);
        public IEnumerable<Employee> GetAllWithRelatedData();
        public Employee GetAllWithRelatedData(string employeeId);
        public Dictionary<string, int> DepartmentWiseEmployee();
    }
}
