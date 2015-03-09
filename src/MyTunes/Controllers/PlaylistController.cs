using System.Web.Mvc;
using MyTunes.Services;

namespace MyTunes.Controllers
{
    public class PlaylistController : Controller
    {
        // GET: Playlist
        public ActionResult Index()
        {
            var playListService = new PlayListService();
            var playlists = playListService.GetPlayLists("userName");
            return View(playlists);
        }
    }
}