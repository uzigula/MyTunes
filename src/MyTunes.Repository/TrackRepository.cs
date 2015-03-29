using System;
using System.Data.Entity;
using System.Linq;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class TrackRepository : BaseRepository<Track>
    {
        private ChinookContext _context;

        public TrackRepository(DbContext context):base(context)
        {
        }

    }
}
