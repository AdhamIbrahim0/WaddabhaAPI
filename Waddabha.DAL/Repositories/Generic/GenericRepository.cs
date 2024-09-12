using Microsoft.EntityFrameworkCore;
using Waddabha.DAL.Data.Context;

namespace Waddabha.DAL.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public TEntity? GetById(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity? Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }
        public async Task<TEntity>? AddAsync(TEntity entity)
        {
          await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity? Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return entity;
        }
    }
}
