using System.Data.Entity;
using System.Linq;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class BaseRepository<TEntity,TContext> : IRepository<TEntity>
        where TEntity:EntityBase
        where TContext : DbContext
    {
        protected TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            // close every object that uses I/O resources
        }

        public IQueryable<TEntity> Get()
        {
           return _context.Set<TEntity>().AsQueryable();
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}