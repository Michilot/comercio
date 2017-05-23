using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using EC.MVC.Application;
using EC.MVC.Application.Interfaces;
using EC.MVC.Data.Repositories;
using EC.MVC.Domain.Interfaces.Repositories;
using EC.MVC.Domain.Interfaces.Services;
using EC.MVC.Domain.Services;

namespace WCF.ElComercio.DI
{
    public class WCFNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Injects the constructors of all DI-ed objects 
            //with a LinqToSQL implementation of IRepository
            //APLICACION
            Bind<IBancoAppService>().To<BancoAppService>();
            Bind<ISucursalAppService>().To<SucursalAppService>();
            Bind<IEstadoAppService>().To<EstadoAppService>();
            Bind<IMonedaAppService>().To<MonedaAppService>();
            Bind<IOrdenPagoAppService>().To<OrdenPagoAppService>();
            //SERVICIOS
            Bind<IBancoService>().To<BancoService>();
            Bind<ISucursalService>().To<SucursalService>();
            Bind<IEstadoService>().To<EstadoService>();
            Bind<IMonedaService>().To<MonedaService>();
            Bind<IOrdenPagoService>().To<OrdenPagoService>();
            //REPOSITORIOS
            Bind<IBancoRepository>().To<BancoRepository>();
            Bind<ISucursalRepository>().To<SucursalRepository>();
            Bind<IEstadoRepository>().To<EstadoRepository>();
            Bind<IMonedaRepository>().To<MonedaRepository>();
            Bind<IOrdenPagoRepository>().To<OrdenPagoRepository>();
        }
    }
}
 