using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyTunes.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyTunes.Api.App_Start
{
    public class AuthRepository : IDisposable
    {
        private AuthContext context;
        private UserManager<IdentityUser> userManager;
        public AuthRepository()
        {
            context = new AuthContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new IdentityUser { UserName = userModel.UserName };
            var result = await userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            return await userManager.FindAsync(userName, password);
        }

        public void Dispose()
        {
            userManager.Dispose();
            context.Dispose();
        }
    }
}