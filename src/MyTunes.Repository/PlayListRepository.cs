using System.Data.Entity;
using System.Linq;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class PlayListRepository : BaseRepository<Playlist>
    {

        public PlayListRepository(DbContext context)
            : base(context)
        {
        }

    }
}
