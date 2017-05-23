using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Application.Interfaces;
using EC.MVC.Domain.Entities;
using EC.MVC.Domain.Interfaces.Services;


namespace EC.MVC.Application
{
    public class BancoAppService : IBancoAppService
    {
        private readonly IBancoService _IBancoService;

        public BancoAppService(IBancoService IBancoService)
        {
            _IBancoService = IBancoService;
        }

        public bool Agregar(Banco obj)
        {
            return _IBancoService.Agregar(obj);
        }

        public string Validar(Banco obj)
        {
            return _IBancoService.Validar(obj);
        }

        public bool Actualizar(Banco obj)
        {
            return _IBancoService.Actualizar(obj);
        }

        public bool Eliminar(Banco obj)
        {
            return _IBancoService.Eliminar(obj);
        }

        public Banco ListarPorId(Banco obj)
        {
            return _IBancoService.ListarPorId(obj);
        }

        public List<Banco> ListarTodos()
        {
            return _IBancoService.ListarTodos();
        }

        public void Dispose()
        {
            _IBancoService.Dispose();
        }
    }
}
