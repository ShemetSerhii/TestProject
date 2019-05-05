using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);

        TEntity Update(TEntity entity);

        Task Delete(int id);

        Task<TEntity> FindAsync(int id);

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filters = null,
            params Expression<Func<TEntity, object>>[] includes);
    }
}
