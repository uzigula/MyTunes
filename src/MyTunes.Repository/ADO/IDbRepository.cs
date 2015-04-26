using MyTunes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunes.Repository.ADO
{
    interface IDbRepository<TEntity>
       where TEntity:EntityBase
    {
        IQueryable<TEntity> Get();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
