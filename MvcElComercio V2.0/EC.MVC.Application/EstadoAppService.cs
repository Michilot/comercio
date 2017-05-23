using System.Collections.Generic;
using EC.MVC.Application.Interfaces;
using EC.MVC.Domain.Entities;
using EC.MVC.Domain.Interfaces.Services;

namespace EC.MVC.Application
{
    public class EstadoAppService : IEstadoAppService
    {
        private readonly IEstadoService _iEstadoService;

        public EstadoAppService(IEstadoService iEstadoService)
        {
            _iEstadoService = iEstadoService;
        }

        public List<Estado> ListarTodos()
        {
            return _iEstadoService.ListarTodos();
        }
    }
}
