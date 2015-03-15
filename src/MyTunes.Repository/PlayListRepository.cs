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
        //Change Signature - Refactoring
        public IEnumerable<Playlist> Get(int customerId)
        {
            return _context.Playlist.Where(x => x.CustomerId == customerId).AsEnumerable();
        }

        public void Dispose()
        {
            _context = null;
        }
    }
}
