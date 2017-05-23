using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Domain.Entities;

namespace EC.MVC.Domain.Interfaces.Services
{
    public interface IMonedaService
    {
        List<Moneda> ListarTodos();
    }
}
