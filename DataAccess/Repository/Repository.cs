using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Entities;

namespace DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _entitySet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entitySet = _context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _entitySet.AddAsync(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public async Task Delete(int id)
        {
           var entity = await _entitySet.FindAsync(id);

           if (entity != null)
           {
               _entitySet.Remove(entity);
            }
        }

        public Task<TEntity> FindAsync(int id)
        {
            return _entitySet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> selector = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _entitySet;

            if (includeProperties.Any())
            {
                query = Include(includeProperties);
            }

            if (selector != null)
            {
                query = query.Where(selector);
            }         

            return await query.ToListAsync();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _entitySet.AsNoTracking();

            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }       
    }
}
