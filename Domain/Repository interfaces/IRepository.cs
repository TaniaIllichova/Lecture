using System.Linq.Expressions;

namespace Domain.Repository_interfaces
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetAllByCondition(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByCondition(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> Add(TEntity entity);
    }
}