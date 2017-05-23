using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Application.Interfaces;
using EC.MVC.Domain.Interfaces.Services;
using EC.MVC.Domain.Entities;

namespace EC.MVC.Application
{
    public class MonedaAppService : IMonedaAppService
    {
        private readonly IMonedaService _iMonedaService;

        public MonedaAppService(IMonedaService iMonedaService)
        {
            _iMonedaService = iMonedaService;
        }

        public List<Moneda> ListarTodos()
        {
            return _iMonedaService.ListarTodos();
        }
    }
}
