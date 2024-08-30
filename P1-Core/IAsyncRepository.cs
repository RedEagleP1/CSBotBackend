namespace P1_Core
{
    public interface IAsyncRepository<TEntity>
    {
        Task<int> Add(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}