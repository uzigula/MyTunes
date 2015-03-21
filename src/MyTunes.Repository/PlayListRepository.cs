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
        
        public IEnumerable<Playlist> Get(int customerId)
        {
            return _context.Playlist.Where(x => x.CustomerId == customerId).AsEnumerable();
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
    }
}
