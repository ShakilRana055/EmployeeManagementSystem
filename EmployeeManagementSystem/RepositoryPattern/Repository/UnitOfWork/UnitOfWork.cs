using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.RepositoryPattern.Interface.GeneralInterface;
using EmployeeManagementSystem.RepositoryPattern.Interface.IUnitOfWork;
using EmployeeManagementSystem.RepositoryPattern.Repository.GeneralRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.RepositoryPattern.Repository.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext databaseConnection)
        {
            context = databaseConnection;

            #region Assigning Variable
            Department = new DepartmentRepository(context);
            CompanyInformation = new CompanyInformationRepository(context);
            Employee = new EmployeeRepository(context);
            SalaryStructure = new SalaryStructureRepository(context);
            #endregion
        }

        #region SaveChanges
        public int Save()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
        #endregion

        #region Implementation
        public IDepartmentRepository Department {get; private set;}
        public ICompanyInformationRepository CompanyInformation { get; private set;}
        public IEmployeeRepository Employee { get; private set;}
        public ISalaryStructureRepository SalaryStructure { get; private set;}
        #endregion
    }
}
