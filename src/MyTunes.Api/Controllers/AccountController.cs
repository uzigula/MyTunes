using Microsoft.AspNet.Identity;
using MyTunes.Api.App_Start;
using MyTunes.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyTunes.Api.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository repository;
        public AccountController()
        {
            repository = new AuthRepository(); 
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await repository.RegisterUser(userModel);

            var errorResult = GetErrorResult(result);
            if (errorResult != null) return errorResult;

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) repository.Dispose();

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null) return InternalServerError();
            if (!result.Succeeded)
            {
                if (result.Errors != null)
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error);

                if (ModelState.IsValid) return BadRequest();
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}
