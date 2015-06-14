using Microsoft.Owin.Security.OAuth;
using MyTunes.Api.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyTunes.Api.ServerProviders
{
    public class PropietaryAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // hace login
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var repository = new AuthRepository())
            {
                var user = await repository.FindUser(context.UserName, context.Password);

                if (user==null)
                {
                    context.SetError("acceso denegado", "El usuario y/o password son incorrectos");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user")); // esto podria venir el identity db
            // podemos agregar mas informacion al token
            // mas informacion el token se hace mas grande
            context.Validated(identity);
        }
    }
}
