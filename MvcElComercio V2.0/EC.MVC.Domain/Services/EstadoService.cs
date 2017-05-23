using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Domain.Interfaces.Repositories;
using EC.MVC.Domain.Interfaces.Services;

namespace EC.MVC.Domain.Services
{
    public class EstadoService : IEstadoService
    {

        private readonly IEstadoRepository _iEstadoRepository;

        public EstadoService(IEstadoRepository iEstadoRepository)
        {
            _iEstadoRepository = iEstadoRepository;
        }

        public List<Entities.Estado> ListarTodos()
        {
            return _iEstadoRepository.ListarTodos();
        }
    }
}
