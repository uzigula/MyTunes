using System.Data.Entity;
using System.Linq;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class PlayListRepository : IRepository<Playlist>
    {
        private ChinookContext _context;

        public PlayListRepository(DbContext context)
        {
            _context = (ChinookContext)(context);
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
