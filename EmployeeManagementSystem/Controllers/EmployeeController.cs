using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.HelperAndConstant;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.RepositoryPattern.Interface.IUnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork context;

        public EmployeeController(IUnitOfWork _work)
        {
            context = _work;
        }
        public IActionResult CreateEmployee()
        {
            var departmentList = context.Department.GetAll().ToList();
            var employee = new EmployeeVM()
            {
                Department = EmployeeHelper.Department(departmentList),
            };
            return View(employee);
        }
    }
}
