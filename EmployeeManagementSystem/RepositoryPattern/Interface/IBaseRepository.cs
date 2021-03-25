using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.RepositoryPattern.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        #region Searching Objects
        TEntity GetById(int Id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region Saving objects
        void Add(TEntity entity);
        void AddAll(IEnumerable<TEntity> entities);
        #endregion

        #region Removing objects
        void Remove(TEntity entity);
        void RemoveAll(IEnumerable<TEntity> entities);
        #endregion
    }
}
