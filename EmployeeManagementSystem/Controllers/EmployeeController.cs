using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagementSystem.EntityModel;
using EmployeeManagementSystem.HelperAndConstant;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.RepositoryPattern.Interface.IUnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork context;
        private readonly IMapper mapper;
        private readonly IImageProcessing image;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public EmployeeController(IUnitOfWork _work, IMapper _mapper, 
                                    IImageProcessing _image, UserManager<ApplicationUser> _userManager,
                                    RoleManager<IdentityRole> _roleManager)
        {
            context = _work;
            mapper = _mapper;
            image = _image;
            userManager = _userManager;
            roleManager = _roleManager;
        }

        #region Actions

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            var departmentList = context.Department.GetAll().ToList();
            var employee = new EmployeeVM()
            {
                Department = EmployeeHelper.Department(departmentList),
            };
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeVM model)
        {
            var salaryStructure = mapper.Map<SalaryStructureVM, SalaryStructure>(model.SalaryStructure);
            var employee = mapper.Map<EmployeeVM, Employee>(model);

            //uploading Images and Mapping
            employee.CreatedBy = User.Identity.Name;
            employee.SalaryStructureId = salaryStructure.Id;
            employee.EmployeeStatus = EmployeeStatus.Active;
            employee.SalaryStructure.EmployeeId = model.EmployeeId;

            if(model.Photo != null)
                employee.PhotoUrl = UploadImage("EmployeeImage", model.Photo, "employee\\photo");
            if(model.NIDPhoto != null)
                employee.NIDUrl = UploadImage("EmployeeNID", model.NIDPhoto, "employee\\nid");
            if(model.BirthCertificate != null)
                employee.BirthCertificateUrl = UploadImage("EmployeeBC", model.BirthCertificate, "employee\\bc");

            context.Employee.Add(employee);
            context.Save();

            //creating Account and Assigning to Employee Role
            await CreateAccount(employee.PhotoUrl, employee.EmployeeId);

            return Json(true);
        }

        [HttpGet]
        public IActionResult EmployeeList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetEmployeeList()
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


            var employeeList = context.Employee.GetAllWithRelatedData().ToList();

            #region Filtering table data
            // searching 
            if (searchValue != null)
            {
                try
                {
                    var list = employeeList.Where(
                        x => x.Name.ToLower().Contains(searchValue) ||
                        x.EmployeeId.ToLower().Contains(searchValue) ||
                        x.Department.Name.ToLower().Contains(searchValue) ||
                        x.Phone.ToLower().Contains(searchValue)).ToList();
                    employeeList = list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            #endregion

            var lists = employeeList.OrderByDescending(x => x.Id).ToList();

            //total number of rows count     
            recordsTotal = lists.Count();

            //Paging     
            var data = lists.Skip(skip).Take(pageSize).ToList();

            //Returning Json Data    
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }

        #endregion

        #region Helpers
        [HttpGet]
        public IActionResult EmployeeId(int id)
        {
            Department department = context.Department.GetById(id);
            Employee employee = context.Employee.GetLastEmployee(department.Code);
            string previousEmployeeId = employee != null && employee.EmployeeId != null ? employee.EmployeeId : "0";
            string employeeId = AutoGenerate.EmployeeId(previousEmployeeId, department.Code);
            return Json(employeeId);
        }
        private string UploadImage(string prefix, IFormFile photo, string folderName)
        {
            string fileName = image.GetUniqueImageName(prefix, photo);
            string imagePath = image.GetImagePath(fileName, folderName);
            string dbImagePath = image.GetImagePathForDb(imagePath);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                photo.CopyTo(stream);
            }
            return dbImagePath;
        }
        private async Task CreateAccount(string photoUrl, string employeeId)
        {
            var user = new ApplicationUser()
            {
                UserName = employeeId,
                Email = employeeId,
                PhotoUrl = photoUrl,
                EmployeeId = employeeId,
            };
            string defaultPassword = context.CompanyInformation.GetAll().FirstOrDefault().PasswordForAll;
            await userManager.CreateAsync(user, defaultPassword);

            // Assigning to EmployeeRole
            var userInformation = await userManager.FindByEmailAsync(employeeId);
            var role = await roleManager.FindByNameAsync(RoleHelper.Employee);
            await userManager.AddToRoleAsync(userInformation, role.Name);
        }
        
        [HttpGet]
        public IActionResult EmployeePieChart()
        {
            var departmentWiseEmployee = context.Employee.DepartmentWiseEmployee();
            return Json(departmentWiseEmployee);
        }
        #endregion
    }
}
