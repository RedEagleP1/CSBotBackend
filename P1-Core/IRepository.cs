namespace P1_Core
{
    public interface IRepository<TEntity>
    {
        //TODO:CAP consider adding a queryable return type for more complex queries
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Query();
    }

    public interface IRepositoryAsync<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> Query();
    }
}