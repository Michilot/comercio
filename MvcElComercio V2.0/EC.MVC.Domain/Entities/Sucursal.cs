using System;

namespace EC.MVC.Domain.Entities
{
    public class Sucursal
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Direccion { set; get; }
        public DateTime Fecha { set; get; }
        public Banco Banco { set; get; }
    }
}
