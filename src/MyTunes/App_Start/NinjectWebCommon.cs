using System.Web.Mvc;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MyTunes.Repository;
using Ninject.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MyTunes.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MyTunes.App_Start.NinjectWebCommon), "Stop")]

namespace MyTunes.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                kernel.Bind(
                    o => o.FromAssemblyContaining<PlayListRepository>()
                        .SelectAllClasses()
                        .WhichAreNotGeneric()
                        .InheritedFrom(typeof(IRepository<>))
                        .BindAllInterfaces()
                    );
                kernel.Bind<ChinookContext>().ToSelf().InRequestScope();
                //Configuracion para Identity
                kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
                kernel.Bind<IUserStore<ApplicationUser>>()
                    .To<UserStore<ApplicationUser>>()
                    .InRequestScope()
                    .WithConstructorArgument("context", kernel.Get<ApplicationDbContext>());
                kernel.Bind<UserManager<ApplicationUser>>()
                    .ToSelf().InRequestScope();
                kernel.Bind<IAuthenticationManager>()
                    .ToMethod(
                        m => HttpContext.Current.GetOwinContext().Authentication
                    ).InRequestScope();

                kernel.Bind<IRoleStore<IdentityRole,string>>()
                    .To<RoleStore<IdentityRole>>()
                    .InRequestScope()
                    .WithConstructorArgument("context", kernel.Get<ApplicationDbContext>());

                kernel.Bind<RoleManager<IdentityRole>>().ToSelf().InRequestScope();
                // finde inyeccion de dependencias para Identity
                //Le digo a MVC que use ese resolver para crear los controllers
                DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }
}
