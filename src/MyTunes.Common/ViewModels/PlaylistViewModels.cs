using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyTunes.Dominio;

namespace MyTunes.Common.ViewModels
{
    public class PlayListViewModel
    {
        public PlayListViewModel()
        {

        }
        public PlayListViewModel(Playlist playList)
        {

            this.Id = playList.Id;
            this.Nombre = playList.Name;

        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Calificacion { get; set; }
        public string CustomerUserName { get; set; }
    }

    public class PlaylistCreateViewModel
    {
        [Required]
        [MaxLength(120, ErrorMessage = "{0} debe ser de un máximo 120 Caracteres")]
        public string Nombre { get; set; }
        public string CustomerUserName { get; set; }
    }

    public class PlaylistEditViewModel
    {

        public string Name { get; set; }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public IEnumerable<TracksListViewModel> Tracks { get; set; }
    }

    public class TracksListViewModel
    {
        public TracksListViewModel(Track track, int playListId)
        {
            Id = track.Id;
            PlayListId = playListId;
            Name = track.Name;
            AlbumTitle = track.Album.Title;
            AlbumArtistName = track.Album.Artist.Name;
        }

        public int Id { get; set; }
        [Display(Name = "Canción")]

        public string Name { get; set; }
        [Display(Name = "Album")]
        public string AlbumTitle { get; set; }
        [Display(Name = "Artista")]
        public string AlbumArtistName { get; set; }
        public int PlayListId { get; set; }

    }

    public class PlaylistSearchTrackViewModel
    {
        public int PlayListId { get; set; }
        public string TrackName { get; set; }
        public IEnumerable<TracksListViewModel> TrackFound { get; set; }

        public object FormTitle { get; set; }
    }
}
