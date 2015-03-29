using System;
using System.Data.Entity;
using System.Linq;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class TrackRepository : IRepository<Track>
    {
        private ChinookContext _context;

        public TrackRepository(DbContext context)
        {
            _context = (ChinookContext)(context);
        }

        public IQueryable<Track> Get()
        {
            return _context.Track.AsQueryable();
        }

        public void Dispose()
        {
            _context = null;
        }


        public void Create(Track entity)
        {
            _context.Track.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Track entity)
        {
            throw new NotImplementedException();
        }
    }
}
