using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class BaseRepository<TEntity,TContext> : IRepository<TEntity>
        where TEntity:EntityBase
        where TContext:DbContext
    {
        protected TContext Context;

        public BaseRepository(TContext context)
        {
            Context = context;
        }
        public IQueryable<TEntity> Get()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Dispose()
        {
           // Cerrar todos los recursos I/O usados 
        }
    }
}
