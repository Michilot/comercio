using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.MVC.Domain.Entities;

namespace EC.MVC.Application.Interfaces
{
    public interface IOrdenPagoAppService
    {
        bool Agregar(OrdenPago obj);

        bool Actualizar(OrdenPago obj);

        bool Eliminar(OrdenPago obj);

        OrdenPago ListarPorId(OrdenPago obj);

        List<OrdenPago> ListarTodos();

        List<OrdenPago> ListarPorMoneda(Moneda oMoneda, Sucursal oSucursal);
    }
}
