using System;
using System.Collections.Generic;
using EC.MVC.Domain.Entities;
using EC.MVC.Domain.Interfaces.Repositories;
using EC.MVC.Domain.Interfaces.Services;

namespace EC.MVC.Domain.Services
{
    public class OrdenPagoService : IOrdenPagoService
    {

        private readonly IOrdenPagoRepository _iOrdenPagoRepository;

        public OrdenPagoService(IOrdenPagoRepository iOrdenPagoRepository)
        {
            _iOrdenPagoRepository = iOrdenPagoRepository;
        }

        public bool Agregar(OrdenPago obj)
        {
            return _iOrdenPagoRepository.Agregar(obj);
        }

        public bool Actualizar(OrdenPago obj)
        {
            return _iOrdenPagoRepository.Actualizar(obj);
        }

        public bool Eliminar(OrdenPago obj)
        {
            return _iOrdenPagoRepository.Eliminar(obj);
        }

        public OrdenPago ListarPorId(OrdenPago obj)
        {
            return _iOrdenPagoRepository.ListarPorId(obj);
        }

        public List<OrdenPago> ListarTodos()
        {
            return _iOrdenPagoRepository.ListarTodos();
        }

        public List<OrdenPago> ListarPorMoneda(Moneda oMoneda, Sucursal oSucursal)
        {
            return _iOrdenPagoRepository.ListarPorMoneda(oMoneda, oSucursal);
        }
    }
}
