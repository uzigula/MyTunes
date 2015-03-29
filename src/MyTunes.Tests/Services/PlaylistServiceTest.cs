using System;
using System.Linq;
using FluentAssertions;
using MyTunes.Dominio;
using MyTunes.Repository;
using MyTunes.Services;
using Ninject;
using NUnit.Framework;
using Ninject.Extensions.Conventions;
using Rhino.Mocks;
using System.Collections.Generic;

namespace MyTunes.Tests.Services
{
    [TestFixture]
    public class PlaylistServiceTest
    {
        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "Cliente no encontrado NonUser")]
        public void GetlayLists_GivingAnInvalidUser_ReturnAnException()
        {
            var playListRepositoryStub = MockRepository.GenerateMock<IRepository<Playlist>>();
            var customerRepositoryStub = MockRepository.GenerateMock<IRepository<Customer>>();
            var tracRepositoryStub = MockRepository.GenerateMock<IRepository<Track>>();
            var playListService = new PlayListService(playListRepositoryStub, customerRepositoryStub, tracRepositoryStub);
            customerRepositoryStub.Stub(m => m.Get()).Return(new EnumerableQuery<Customer>(new List<Customer>()));
            var playlists = playListService.GetPlayLists("NonUser");
        }

        [Test]
        public void GetlayLists_GivingAValidUser_ReturnEmptyList()
        {
            var playListRepositoryStub = MockRepository.GenerateMock<IRepository<Playlist>>();
            var customerRepositoryStub = MockRepository.GenerateMock<IRepository<Customer>>();
            var tracRepositoryStub = MockRepository.GenerateMock<IRepository<Track>>();
            var playListService = new PlayListService(playListRepositoryStub, customerRepositoryStub, tracRepositoryStub);
            customerRepositoryStub.Stub(m => m.Get()).Return(new EnumerableQuery<Customer>(new List<Customer>(){new Customer{Email = "user@example.com",Id =1}}));
            playListRepositoryStub.Stub(m => m.Get()).Return(new EnumerableQuery<Playlist>(new List<Playlist>()));
            var playlists = playListService.GetPlayLists("user@example.com");
            playlists.Should().BeEmpty();
        }
    }
}
