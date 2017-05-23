using System;
using System.Collections.Generic;
using EC.MVC.Application.Interfaces;
using EC.MVC.Domain.Entities;
using EC.MVC.Domain.Interfaces.Services;

namespace EC.MVC.Application
{
    public class OrdenPagoAppService : IOrdenPagoAppService
    {
        private readonly IOrdenPagoService _iOrdenPagoService;

        public OrdenPagoAppService(IOrdenPagoService iOrdenPagoService)
        {
            _iOrdenPagoService = iOrdenPagoService;
        }

        public bool Agregar(OrdenPago obj)
        {
            return _iOrdenPagoService.Agregar(obj);
        }

        public bool Actualizar(OrdenPago obj)
        {
            return _iOrdenPagoService.Actualizar(obj);
        }

        public bool Eliminar(OrdenPago obj)
        {
            return _iOrdenPagoService.Eliminar(obj);
        }

        public OrdenPago ListarPorId(OrdenPago obj)
        {
            return _iOrdenPagoService.ListarPorId(obj);
        }

        public List<OrdenPago> ListarTodos()
        {
            return _iOrdenPagoService.ListarTodos();
        }

        public List<OrdenPago> ListarPorMoneda(Moneda oMoneda, Sucursal oSucursal)
        {
            return _iOrdenPagoService.ListarPorMoneda(oMoneda, oSucursal);
        }
    }
}
