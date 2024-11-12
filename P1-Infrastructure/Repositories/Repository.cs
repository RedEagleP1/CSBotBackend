using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Entities;
using P1_Core.Interfaces;
using P1_Infrastructure.Database;

namespace P1_Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly P1DatabaseContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(P1DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<int> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(T entity)
        {
            await DeleteAsync(entity.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var foundEntity = await _dbSet.FindAsync(id);
            if (foundEntity != null)
            {
                _dbSet.Remove(foundEntity);
                await _context.SaveChangesAsync();
            }
            //todo need to throw exception on null
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return entities;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var foundEntity = await _dbSet.FindAsync(id);
            if (foundEntity != null)
            {
                return foundEntity;
            }
            throw new Exception("Entity not found");
        }

        public async Task UpdateAsync(T entity)
        {
            var foundEntity = await _dbSet.FindAsync(entity);
            if (foundEntity != null)
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }
    }
}