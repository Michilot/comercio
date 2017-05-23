using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.MVC.Domain.Entities
{
    public class Banco
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Direccion { set; get; }
        public DateTime Fecha { set; get; }
    }

}
