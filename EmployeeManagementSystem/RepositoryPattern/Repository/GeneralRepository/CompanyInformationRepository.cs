using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.EntityModel;
using EmployeeManagementSystem.RepositoryPattern.Interface.GeneralInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.RepositoryPattern.Repository.GeneralRepository
{
    public class CompanyInformationRepository: BaseRepository<CompanyInformation>, ICompanyInformationRepository
    {
        private readonly AppDbContext context;

        public CompanyInformationRepository(AppDbContext appDbContext):base(appDbContext)
        {
            context = appDbContext;
        }
    }
}
