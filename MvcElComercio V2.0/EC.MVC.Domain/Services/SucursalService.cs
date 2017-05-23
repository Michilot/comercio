using System.Collections.Generic;
using EC.MVC.Domain.Entities;
using EC.MVC.Domain.Interfaces.Repositories;
using EC.MVC.Domain.Interfaces.Services;

namespace EC.MVC.Domain.Services
{
    public class SucursalService : ISucursalService
    {

        private readonly ISucursalRepository _iSucursalRepository;

        public SucursalService(ISucursalRepository sucursalRepository)
        {
            _iSucursalRepository = sucursalRepository;
        }

        public bool Agregar(Sucursal obj)
        {
            return _iSucursalRepository.Agregar(obj);
        }

        public bool Actualizar(Sucursal obj)
        {
            return _iSucursalRepository.Actualizar(obj);
        }

        public string Validar(Sucursal obj)
        {
            return _iSucursalRepository.Validar(obj);
        }

        public bool Eliminar(Sucursal obj)
        {
            return _iSucursalRepository.Eliminar(obj);
        }

        public Sucursal ListarPorId(Sucursal obj)
        {
            return _iSucursalRepository.ListarPorId(obj);
        }

        public List<Sucursal> ListarTodos()
        {
            return _iSucursalRepository.ListarTodos();
        }

        public void Dispose()
        {
            _iSucursalRepository.Dispose();
        }


        public List<Sucursal> ListarxBanco(Banco obj)
        {
            return _iSucursalRepository.ListarxBanco(obj);
        }
    }
}
