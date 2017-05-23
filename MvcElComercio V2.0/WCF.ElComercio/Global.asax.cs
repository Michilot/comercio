using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using Ninject;
using Ninject.Web.Common;

using EC.MVC.Application;
using EC.MVC.Application.Interfaces;
using EC.MVC.Data.Repositories;
using EC.MVC.Domain.Interfaces.Repositories;
using EC.MVC.Domain.Interfaces.Services;
using EC.MVC.Domain.Services;

namespace WCF.ElComercio
{
    public class Global : NinjectHttpApplication
    {

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            //APLICACION
            kernel.Bind<IBancoAppService>().To<BancoAppService>().InSingletonScope();
            kernel.Bind<ISucursalAppService>().To<SucursalAppService>().InSingletonScope();
            kernel.Bind<IEstadoAppService>().To<EstadoAppService>().InSingletonScope();
            kernel.Bind<IMonedaAppService>().To<MonedaAppService>().InSingletonScope();
            kernel.Bind<IOrdenPagoAppService>().To<OrdenPagoAppService>().InSingletonScope();
            //SERVICIOS
            kernel.Bind<IBancoService>().To<BancoService>().InSingletonScope();
            kernel.Bind<ISucursalService>().To<SucursalService>().InSingletonScope();
            kernel.Bind<IEstadoService>().To<EstadoService>().InSingletonScope();
            kernel.Bind<IMonedaService>().To<MonedaService>().InSingletonScope();
            kernel.Bind<IOrdenPagoService>().To<OrdenPagoService>().InSingletonScope();
            //REPOSITORIOS
            kernel.Bind<IBancoRepository>().To<BancoRepository>().InSingletonScope();
            kernel.Bind<ISucursalRepository>().To<SucursalRepository>().InSingletonScope();
            kernel.Bind<IEstadoRepository>().To<EstadoRepository>().InSingletonScope();
            kernel.Bind<IMonedaRepository>().To<MonedaRepository>().InSingletonScope();
            kernel.Bind<IOrdenPagoRepository>().To<OrdenPagoRepository>().InSingletonScope();

            return kernel;
        }
    }
}