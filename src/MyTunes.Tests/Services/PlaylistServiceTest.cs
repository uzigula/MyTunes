using System;
using MyTunes.Services;
using NUnit.Framework;

namespace MyTunes.Tests.Services
{
    [TestFixture]
    public class PlaylistServiceTest
    {
        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "Cliente no encontrado Nonuser")]
        public void GetlayLists_GivingAnInvalidUser_ReturnAnException()
        {
            var playListService = new PlayListService();
            var playlists = playListService.GetPlayLists("NonUser");

        }
    }
}
