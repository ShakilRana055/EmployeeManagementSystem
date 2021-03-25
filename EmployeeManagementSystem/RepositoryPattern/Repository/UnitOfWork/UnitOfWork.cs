using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.RepositoryPattern.Interface.IUnitOfWork;
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
            // Employee = new EmployeeRepository(context);
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

        //public IEmployeeRepository Employee {get; private set;}
    }
}
