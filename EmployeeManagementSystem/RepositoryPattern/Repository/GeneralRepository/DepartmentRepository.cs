using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.EntityModel;
using EmployeeManagementSystem.RepositoryPattern.Interface.GeneralInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.RepositoryPattern.Repository.GeneralRepository
{
    public class DepartmentRepository: BaseRepository<Department>, IDepartmentRepository
    {
        private readonly AppDbContext context;
        public DepartmentRepository(AppDbContext dbContext):base(dbContext)
        {
            context = dbContext;
        }
    }
}
