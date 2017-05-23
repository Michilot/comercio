using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Domain.Entities;

namespace EC.MVC.Domain.Interfaces.Repositories
{
    public interface IEstadoRepository
    {
        List<Estado> ListarTodos();
    }

}
