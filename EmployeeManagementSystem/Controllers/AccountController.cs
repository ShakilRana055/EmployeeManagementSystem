using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.EntityModel;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.RepositoryPattern.Interface.IUnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUnitOfWork context;

        public AccountController(UserManager<ApplicationUser> _userManager, 
                                SignInManager<ApplicationUser> _signInManager,
                                RoleManager<IdentityRole> _roleManager,
                                IUnitOfWork unitOfWork)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            context = unitOfWork;
        }

        #region User and Role Addition
        private async Task CreateDefaultRole()
        {
            var roles = roleManager.Roles.ToList();
            if(roles.Count == 0)
            {
                var roleList = new List<string> { "SuperAdmin", "Admin", "HR", "Employee" };
                for (int i = 0; i < roleList.Count; i++)
                {
                    var identityRole = new IdentityRole
                    {
                        Name = roleList[i],
                    };
                    var result = await roleManager.CreateAsync(identityRole);
                }
            }
        }
        private async Task SpecialUser()
        {
            var userCount = userManager.Users.ToList();
            if (userCount.Count == 0)
            {
                var user = new ApplicationUser()
                {
                    UserName = "superadmin@gmail.com",
                    Email = "superadmin@gmail.com",
                    EmployeeId = "superadmin@gmail.com",
                    PhotoUrl = "/superAdmin.png",
                };
                await userManager.CreateAsync(user, "superadmin@123");
            }
        }
        #endregion
        
        public async Task<IActionResult> Login()
        {
            await SpecialUser();
            await CreateDefaultRole();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var user = await signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);
            if (user.Succeeded)
            {
                return RedirectToAction("Index", "Department");
            }
            return View();
        }
    }
}
