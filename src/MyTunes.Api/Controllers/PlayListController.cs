using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyTunes.Common.ViewModels;
using MyTunes.Services.Entities;

namespace MyTunes.Api.Controllers
{
    public class PlayListController : ApiController
    {
        public IEnumerable<PlayListViewModel> Get()
        {
        }
    }
}
