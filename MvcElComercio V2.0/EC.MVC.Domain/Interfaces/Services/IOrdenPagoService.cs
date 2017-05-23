using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Domain.Entities;

namespace EC.MVC.Domain.Interfaces.Services
{
   public interface IOrdenPagoService
    {
        bool Agregar(OrdenPago obj);

        bool Actualizar(OrdenPago obj);

        bool Eliminar(OrdenPago obj);

        OrdenPago ListarPorId(OrdenPago obj);

        List<OrdenPago> ListarPorMoneda(Moneda oMoneda, Sucursal oSucursal);

        List<OrdenPago> ListarTodos();
    }
}
