﻿using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class TrackRepository : BaseRepository<Track,ChinookContext>
    {
        public TrackRepository(ChinookContext context) :base(context)
        {
        }

    }
}
