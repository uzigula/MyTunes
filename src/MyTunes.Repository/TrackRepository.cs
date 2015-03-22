using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class TrackRepository
    {
        private ChinookContext _context;

        public TrackRepository()
        {
            _context = new ChinookContext();
        }

        public IQueryable<Track> Get()
        {
            return _context.Track.AsQueryable();
        }

        public void Dispose()
        {
            _context = null;
        }
    }
}
