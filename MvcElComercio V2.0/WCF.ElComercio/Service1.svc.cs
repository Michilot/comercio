using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EC.MVC.Application;
using EC.MVC.Domain.Entities;

namespace WCF.ElComercio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        private readonly SucursalAppService _sucursalAppService;

        public Service1(SucursalAppService sucursalAppService)
        {
            this._sucursalAppService = sucursalAppService;
        }

        public List<Sucursal> ListarSucursalBancos(Banco Banco)
        {
            List<Sucursal> result = _sucursalAppService.ListarxBanco(Banco);
            return result;
        }
    }
}
