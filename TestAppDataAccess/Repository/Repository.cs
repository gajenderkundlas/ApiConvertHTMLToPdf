using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestAppDataAccess.Repository
{
    public class Repository<T>:IRepository<T> where T : class
    {
        TestAppDBContext dbContext;
        public Repository(TestAppDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            dbContext.SaveChanges();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                dbContext.Set<T>().Remove(entity);
                dbContext.SaveChanges();
            });

        }
        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.Set<T>().Update(entity);
                dbContext.SaveChanges();
            });
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate).ToList();
        }

    }
}
