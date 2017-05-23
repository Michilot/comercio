using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Domain.Interfaces.Services;
using EC.MVC.Domain.Interfaces.Repositories;
using EC.MVC.Domain.Entities;

namespace EC.MVC.Domain.Services
{
    public class BancoService : IBancoService
    {
 
        private readonly IBancoRepository _IBancoRepository;

        public BancoService(IBancoRepository IBancoRepository)
        {
            _IBancoRepository = IBancoRepository;
        }

        public string Validar(Banco obj)
        {
            return _IBancoRepository.Validar(obj);
        }

        public bool Agregar(Banco obj)
        {
            return _IBancoRepository.Agregar(obj);
        }

        public bool Actualizar(Entities.Banco obj)
        {
            return _IBancoRepository.Actualizar(obj);
        }

        public bool Eliminar(Entities.Banco obj)
        {
            return _IBancoRepository.Eliminar(obj);
        }

        public Entities.Banco ListarPorId(Entities.Banco obj)
        {
            return _IBancoRepository.ListarPorId(obj);
        }

        public List<Entities.Banco> ListarTodos()
        {
            return _IBancoRepository.ListarTodos();
        }

        public void Dispose()
        {
            _IBancoRepository.Dispose();
        }
    }
}
