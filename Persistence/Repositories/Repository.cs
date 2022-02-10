using Domain.Repository_interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDBContext _context;

        public Repository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetByCondition(Expression<Func<TEntity, bool>>? filter = null)
        {
            if (filter == null)
            {
                return await _context.Set<TEntity>().FirstOrDefaultAsync();
            }

            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAllByCondition(Expression<Func<TEntity, bool>>? filter = null)
        {
            if (filter == null)
            {
                return await _context.Set<TEntity>().ToListAsync();
            }

            return await _context.Set<TEntity>().Where(filter).ToListAsync();
        }
    }
}