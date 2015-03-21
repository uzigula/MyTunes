using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MyTunes.Models
{
    public class PlayListViewModel
    {
        public PlayListViewModel(Dominio.Playlist playList)
        {
            
            this.Id= playList.Id;
            this.Nombre = playList.Name;
            
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Calificacion { get; set; }
        public string CustomerUserName { get; set; }
    }

    public class PlaylistEditViewModel
    {
        [Required]
        [MaxLength( 120, ErrorMessage = "{0} debe ser de un máximo 120 Caracteres")]
        public string Nombre { get; set; }
        public string CustomerUserName { get; set; }
    }
}
