using AutoMapper;
using EmployeeManagementSystem.EntityModel;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.HelperAndConstant
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<DepartmentVM, Department>();
            CreateMap<EmployeeVM, Employee>();
            CreateMap<SalaryStructureVM, SalaryStructure>();

        }
    }
}
