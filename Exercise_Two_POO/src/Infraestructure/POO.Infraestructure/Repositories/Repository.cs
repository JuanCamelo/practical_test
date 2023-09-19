using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using POO.Domain.Interfaces;
using POO.Infraestructure.Context;
using System.Linq.Expressions;

namespace POO.Infraestructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _dbContext;

        public Repository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<T>(Expression<Func<TEntity, bool>>? whereCondition = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes = null) where T : class
        {
            try
            {
                IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsNoTracking();
                if (includes != null)
                    query = includes(query);
                if (whereCondition != null)
                    query = query.Where(whereCondition);

                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity> GetByIdAsync(string key)
        {
            try
            {
                return await _dbContext.Set<TEntity>().FindAsync(key);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
