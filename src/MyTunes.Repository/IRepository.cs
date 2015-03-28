using System;
using System.Linq;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity:EntityBase
    {
        IQueryable<TEntity> Get();
        void Create(TEntity playList);
        void Update(TEntity playList);
    }
}