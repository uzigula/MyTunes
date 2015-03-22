using System;
using System.Collections.Generic;
using System.Linq;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class PlayListRepository : IDisposable
    {
        private ChinookContext _context;

        public PlayListRepository()
        {
            _context = new ChinookContext();
        }

        public IQueryable<Playlist> Get()
        {
            return _context.Playlist.AsQueryable();
        }

        public void Dispose()
        {
            _context = null;
        }

        public void Create(Playlist playList)
        {
            _context.Playlist.Add(playList);
            _context.SaveChanges();
        }

        public void Update(Playlist playList)
        {
            _context.SaveChanges();
        }
    }
}
