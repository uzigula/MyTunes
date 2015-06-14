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
    [RoutePrefix("api/PlayList")]
    public class PlayListController : ApiController
    {
        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok();
        }

    }
}
