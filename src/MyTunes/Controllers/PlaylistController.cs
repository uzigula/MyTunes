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
        private PlayListService _playListService;

        public PlaylistController()
        {
            _playListService = new PlayListService();
        }

        // GET: Playlist
        public ActionResult Index()
        {
            try
            {
                var playlists = _playListService.GetPlayLists(User.Identity.Name);
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

        public ActionResult Create()
        {
            ViewBag.Title = "New Playlist";
            return View(new PlaylistEditViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaylistEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CustomerUserName = User.Identity.Name;
                    _playListService.Create(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("",ex);
                    ViewBag.Title = "New Playlist";
                    return View(model);
                }
            }
            ModelState.AddModelError("","Model is invalid");
            return View(model);
        }

    }
}