using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Domain.Entities;

namespace EC.MVC.Application.Interfaces
{
    public interface IBancoAppService
    {
        bool Agregar(Banco obj);

        bool Actualizar(Banco obj);

        string Validar(Banco obj);

        bool Eliminar(Banco obj);

        Banco ListarPorId(Banco obj);

        List<Banco> ListarTodos();

        void Dispose();
    }
}
