using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public IEnumerable<Playlist> Get(string userName)
        {
            return _context.Playlist.AsEnumerable();
        }

        public void Dispose()
        {
            _context = null;
        }
    }
}
