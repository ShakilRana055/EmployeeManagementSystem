using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagementSystem.EntityModel;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.RepositoryPattern.Interface.IUnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork context;
        private IMapper mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapperVariable)
        {
            context = unitOfWork;
            mapper = mapperVariable;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DepartmentVM model)
        {
            if(ModelState.IsValid)
            {
                var department = mapper.Map<DepartmentVM, Department>(model);
                context.Department.Add(department);
                return context.Save() > 0 ? Json(true) : Json(false);
            }
            return Json(false);
        }

        public IActionResult Update(DepartmentVM model)
        {
            var department = context.Department.GetById(model.Id);
            if(department != null)
            {
                department = mapper.Map<DepartmentVM, Department>(model);
                return context.Save() > 0 ? Json(true) : Json(false);
            }
            return Json(false);
        }
        public IActionResult Delete(int id)
        {
            var department = context.Department.GetById(id);
            if(department != null)
            {
                context.Department.Remove(department);
                return context.Save() > 0 ? Json(true) : Json(false);
            }
            return Json(false);
        }

        public IActionResult DepartmentList()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault().ToLower();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;


            var departmentList = context.Department.GetAll().ToList();

            #region Filtering table data
            // searching 
            if (searchValue != null)
            {
                try
                {
                    var filterBrandList = departmentList.Where(
                        x => x.Name.ToLower().Contains(searchValue) ||
                        x.Code.ToLower().Contains(searchValue) ||
                        x.Description.ToLower().Contains(searchValue)).ToList();

                    departmentList = filterBrandList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            #endregion

            var lists = departmentList.OrderByDescending(x => x.Id).ToList();

            //total number of rows count     
            recordsTotal = lists.Count();

            //Paging     
            var data = lists.Skip(skip).Take(pageSize).ToList();

            //Returning Json Data    
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }
    }
}
