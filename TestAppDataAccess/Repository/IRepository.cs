using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestAppDataAccess.Repository
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    }
}
