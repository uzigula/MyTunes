using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class PlayListRepository : BaseRepository<Playlist,ChinookContext>
    {
        public PlayListRepository(ChinookContext context)
            : base(context)
        {
        }

    }
}
