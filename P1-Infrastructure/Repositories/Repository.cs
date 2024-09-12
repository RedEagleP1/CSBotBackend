using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Infrastructure.Database;

namespace P1_Infrastructure {
    public class Repository<T> : IRepository<T> where T : class {

        private readonly P1DatabaseContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(P1DatabaseContext context) {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity) {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity) {
            var foundEntity = _dbSet.Find(entity);
            if (foundEntity != null) {
                _dbSet.Remove(foundEntity);
                _context.SaveChanges();
            }
            // TODO:CAP Throw an exception if the entity is not found
        }

        public IEnumerable<T> GetAll() {
            return _dbSet;
            // TODO:CAP consider checking if set is empty now and throwing an exception instead of allowing caller to handle empty set
        }

        public T GetById(int id) {
            var foundEntity = _dbSet.Find(id);
            if (foundEntity != null) {
                return foundEntity;
            }
            // TODO:CAP Throw an exception if the entity is not found, this should be application specific exception
            throw new Exception("Entity not found");
        }

        public void Update(T entity) {
            var foundEntity = _dbSet.Find(entity);
            if (foundEntity != null) {
                _dbSet.Update(entity);
                _context.SaveChanges();
            }
            // TODO:CAP Throw an exception if the entity is not found
        }

        public IQueryable<T> Query() {
            return _dbSet.AsQueryable();
        }
    }
}