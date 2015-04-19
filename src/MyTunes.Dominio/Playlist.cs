namespace MyTunes.Dominio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Playlist")]
    public partial class Playlist : EntityBase
    {
        public Playlist()
        {
            Track = new HashSet<Track>();
        }


        [StringLength(120)]
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public virtual ICollection<Track> Track { get; set; }
    }
}
