using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.MVC.Domain.Entities
{
    public class OrdenPago
    {
        public int Id { set; get; }

        public Sucursal Sucursal { set; get; }

        public Moneda Moneda { set; get; }

        public Estado Estado { set; get; }

        public decimal Monto { set; get; }

        public DateTime Fecha { set; get; }
    }
}
