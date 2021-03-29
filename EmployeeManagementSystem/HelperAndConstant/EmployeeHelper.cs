using EmployeeManagementSystem.EntityModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.HelperAndConstant
{
    public static class EmployeeHelper
    {
        public static List<SelectListItem> Department(List<Department> department)
        {
            List<SelectListItem> departmentList = new List<SelectListItem>();
            departmentList.AddRange(department.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }));
            return departmentList;
        }
    }
}
