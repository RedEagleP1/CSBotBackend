namespace P1_Core
{
    public interface IAsyncRepository<T>
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}