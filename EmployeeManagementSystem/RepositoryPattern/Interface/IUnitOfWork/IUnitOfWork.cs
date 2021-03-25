using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.RepositoryPattern.Interface.IUnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        int Save();
        //public IEmployeeRepository Employee {get;}
    }
}
