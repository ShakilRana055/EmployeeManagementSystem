using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.EntityModel;
using EmployeeManagementSystem.RepositoryPattern.Interface.GeneralInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.RepositoryPattern.Repository.GeneralRepository
{
    public class SalaryStructureRepository : BaseRepository<SalaryStructure>, ISalaryStructureRepository
    {
        private readonly AppDbContext context;

        public SalaryStructureRepository(AppDbContext _context):base(_context)
        {
            context = _context;
        }
    }
}
