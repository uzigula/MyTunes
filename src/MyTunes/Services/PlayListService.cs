using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyTunes.Models;
using MyTunes.Repository;

namespace MyTunes.Services
{
    public class PlayListService : IDisposable
    {
        private PlayListRepository _repository;

        public PlayListService()
        {
            _repository = new PlayListRepository();
        }
        public IEnumerable<PlayListViewModel> GetPlayLists(string userName)
        {
            var playLists = _repository.Get(userName);
            // aqui se tiene que hacer un mapeo del dominio al viewmodel
            return playLists.Select(playList => new PlayListViewModel(playList)).ToList();
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
