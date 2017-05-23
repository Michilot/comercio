using System;
using System.Collections.Generic;
using EC.MVC.Application.Interfaces;
using EC.MVC.Domain.Entities;
using EC.MVC.Domain.Interfaces.Services;

namespace EC.MVC.Application
{
    public class SucursalAppService : ISucursalAppService
    {

        private readonly ISucursalService _iSucursalService;

        public SucursalAppService(ISucursalService iSucursalService)
        {
            _iSucursalService = iSucursalService;
        }

        public bool Agregar(Sucursal obj)
        {
            return _iSucursalService.Agregar(obj);
        }

        public bool Actualizar(Sucursal obj)
        {
            return _iSucursalService.Actualizar(obj);
        }

        public string Validar(Sucursal obj)
        {
            return _iSucursalService.Validar(obj);
        }

        public bool Eliminar(Sucursal obj)
        {
            return _iSucursalService.Eliminar(obj);
        }

        public Sucursal ListarPorId(Sucursal obj)
        {
            return _iSucursalService.ListarPorId(obj);
        }

        public List<Sucursal> ListarTodos()
        {
            return _iSucursalService.ListarTodos();
        }

        public void Dispose()
        {
            _iSucursalService.Dispose();
        }

        public List<Sucursal> ListarxBanco(Banco obj)
        {
            return _iSucursalService.ListarxBanco(obj);
        }
    }
}
