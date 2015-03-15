using System.Web.Mvc;
using MyTunes.Services;
using System.Collections.Generic;
using MyTunes.Models;
using System;

namespace MyTunes.Controllers
{
    [Authorize]
    public class PlaylistController : Controller
    {
        // GET: Playlist
        public ActionResult Index()
        {
            var playListService = new PlayListService();

            try
            {
                var playlists = playListService.GetPlayLists(User.Identity.Name);
                ViewBag.Titulo = "My PlayList";
                return View(playlists);
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Titulo = "Error!!" + ex.Message;
                return View(new List<PlayListViewModel>());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}