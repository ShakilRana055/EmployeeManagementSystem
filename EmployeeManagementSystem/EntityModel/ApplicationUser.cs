using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.EntityModel
{
    public class ApplicationUser: IdentityUser
    {
        public string EmployeeId { get; set; }
        public string PhotoUrl { get; set; }
    }
}
