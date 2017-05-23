using EC.MVC.Application;
using EC.MVC.Application.Interfaces;
using EC.MVC.Data.Repositories;
using EC.MVC.Domain.Interfaces.Repositories;
using EC.MVC.Domain.Interfaces.Services;
using EC.MVC.Domain.Services;
using System.Web.Http;
using Ninject.Web.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EC.ElComercio.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(EC.ElComercio.App_Start.NinjectWebCommon), "Stop")]

namespace EC.ElComercio.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
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
            //APLICACION
            kernel.Bind<IBancoAppService>().To<BancoAppService>();
            kernel.Bind<ISucursalAppService>().To<SucursalAppService>();
            kernel.Bind<IEstadoAppService>().To<EstadoAppService>();
            kernel.Bind<IMonedaAppService>().To<MonedaAppService>();
            kernel.Bind<IOrdenPagoAppService>().To<OrdenPagoAppService>();
            //SERVICIOS
            kernel.Bind<IBancoService>().To<BancoService>();
            kernel.Bind<ISucursalService>().To<SucursalService>();
            kernel.Bind<IEstadoService>().To<EstadoService>();
            kernel.Bind<IMonedaService>().To<MonedaService>();
            kernel.Bind<IOrdenPagoService>().To<OrdenPagoService>();
            //REPOSITORIOS
            kernel.Bind<IBancoRepository>().To<BancoRepository>();
            kernel.Bind<ISucursalRepository>().To<SucursalRepository>();
            kernel.Bind<IEstadoRepository>().To<EstadoRepository>();
            kernel.Bind<IMonedaRepository>().To<MonedaRepository>();
            kernel.Bind<IOrdenPagoRepository>().To<OrdenPagoRepository>();
        }
    }
}
