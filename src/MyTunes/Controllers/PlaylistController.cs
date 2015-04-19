using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Http;
using MyTunes.Common.ViewModels;
using MyTunes.Services.Entities;

namespace MyTunes.Controllers
{
    [Authorize]
    public class PlaylistController : Controller
    {
        private PlayListService _playListService;

        public PlaylistController(PlayListService playListService)
        {
            _playListService = playListService;
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
                ModelState.AddModelError("","Cliente no registrado");
                return View(new List<PlayListViewModel>());
            }
            catch (Exception ex)
            {
                throw; // redirigir a una pagina de error
            }
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Playlist";
            return View(new PlaylistCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaylistCreateViewModel model)
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


        public ActionResult Edit(int id)
        {
            return View(_playListService.Get(id));
        }

        public ActionResult SearchTrack(int id,string Name)
        {
            var model = new PlaylistSearchTrackViewModel()
            {
                FormTitle = Name,
                PlayListId = id,
                TrackFound = new List<TracksListViewModel>()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult GetTrackList(PlaylistSearchTrackViewModel model)
        {
            var tracks = _playListService.GetTracksFrom(model);

            return PartialView("Shared/_TrackListEdit", tracks);
        }

        [HttpPost]
        public JsonResult AddTrack(int playListId, int trackId)
        {
            _playListService.AddTrack(playListId, trackId);
            return Json(new HttpResponseMessage(HttpStatusCode.OK)) ;
        }

    }
}