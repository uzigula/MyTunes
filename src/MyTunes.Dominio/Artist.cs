namespace MyTunes.Dominio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Artist")]
    public partial class Artist : EntityBase
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }


        [StringLength(120)]
        public string Name { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}
