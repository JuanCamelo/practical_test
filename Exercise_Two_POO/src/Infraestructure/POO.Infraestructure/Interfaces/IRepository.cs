using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace POO.Domain.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> GetAllAsync<T>(Expression<Func<TEntity, bool>>? whereCondition = null,
                                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes = null) where T : class;
        Task AddAsync(TEntity entity);
    }
}
