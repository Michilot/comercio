using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Domain.Entities;

namespace EC.MVC.Application.Interfaces
{
    public interface IMonedaAppService
    {
        List<Moneda> ListarTodos();
    }
}
