using System.Collections.Generic;
using EC.MVC.Domain.Entities;

namespace EC.MVC.Application.Interfaces
{
    public interface ISucursalAppService
    {
        bool Agregar(Sucursal obj);

        bool Actualizar(Sucursal obj);

        string Validar(Sucursal obj);

        bool Eliminar(Sucursal obj);

        Sucursal ListarPorId(Sucursal obj);

        List<Sucursal> ListarTodos();

        List<Sucursal> ListarxBanco(Banco obj);

        void Dispose();
    }
}
