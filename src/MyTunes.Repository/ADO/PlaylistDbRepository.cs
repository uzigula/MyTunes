using MyTunes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunes.Repository.ADO
{
    public class PlaylistDbRepository : IRepository<Playlist>
    {
        private IDatabaseContext databaseContext;
        public PlaylistDbRepository(IDatabaseContext context)
        {
            databaseContext = context;
        }


        public IQueryable<Playlist> Get()
        {
            var lista = new List<Playlist>();
            var reader = databaseContext.ExecuteQuery("la consulta", new Parameter[]{});
            //recorrer el datareader y crear una lista<PlayList>
            while (reader.Read())
            {
                lista.Add(new Playlist()
                {
                    Id = reader.GetInt32(0),

                }
                    );
            }

            return lista.AsQueryable<Playlist>();
        }

        public void Create(Playlist entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Playlist entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
