using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Domain.Interfaces.Repositories;
using EC.MVC.Domain.Interfaces.Services;

namespace EC.MVC.Domain.Services
{
    public class MonedaService : IMonedaService
    {
        private readonly IMonedaRepository _iMonedaRepository;

        public MonedaService(IMonedaRepository iMonedaRepository)
        {
            _iMonedaRepository = iMonedaRepository;
        }

        public List<Entities.Moneda> ListarTodos()
        {
            return _iMonedaRepository.ListarTodos();
        }
    }
}
