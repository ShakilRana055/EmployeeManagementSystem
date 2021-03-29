using EmployeeManagementSystem.RepositoryPattern.Interface.GeneralInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.RepositoryPattern.Interface.IUnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        int Save();
        public IDepartmentRepository Department { get; }
        public ICompanyInformationRepository CompanyInformation { get; }
    }
}
