using P1_Core.Entities;
using P1_Core.Entities.Interfaces;

namespace P1_Core
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> Query();
    }
}