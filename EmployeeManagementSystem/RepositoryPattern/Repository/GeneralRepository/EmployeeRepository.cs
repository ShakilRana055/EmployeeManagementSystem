using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.EntityModel;
using EmployeeManagementSystem.RepositoryPattern.Interface.GeneralInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.RepositoryPattern.Repository.GeneralRepository
{
    public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext context;

        public EmployeeRepository(AppDbContext _context):base(_context)
        {
            context = _context;
        }

        public Employee GetLastEmployee(string departmentCode)
        {
            var lastEmployee = context.Employee.OrderBy(item => item.EmployeeId).LastOrDefault(item => item.EmployeeId.Contains(departmentCode));
            return lastEmployee;
        }

        public IEnumerable<Employee> GetAllWithRelatedData()
        {
            var result = context.Employee
                                .Include(item => item.Department)
                                .Include(item => item.SalaryStructure)
                                .ToList();
            return result;
                                
        }

        public Employee GetAllWithRelatedData(string employeeId)
        {
            var result = context.Employee
                                .Include(item => item.Department)
                                .Include(item => item.SalaryStructure)
                                .Where(item => item.EmployeeId == employeeId)
                                .FirstOrDefault();
            return result;
        }

        public Dictionary<string, int> DepartmentWiseEmployee()
        {
            var result = context.Employee
                .Include(item => item.Department)
                .ToList()
                .GroupBy(item => item.DepartmentId).ToList();

            Dictionary<string, int> storage = new Dictionary<string, int>();

            foreach (var item in result)
            {
                var departmentName = item.FirstOrDefault().Department.Name;
                var departmentId = item.FirstOrDefault().DepartmentId;
                int count = context.Employee.Where(item => item.DepartmentId == departmentId).ToList().Count();
                storage.Add(departmentName, count);
            }
            return storage;
        }
    }
}
