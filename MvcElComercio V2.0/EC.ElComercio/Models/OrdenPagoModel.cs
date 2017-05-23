using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EC.MVC.Domain.Entities;

namespace EC.ElComercio.Models
{
    public class OrdenPagoModel
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Por favor seleccione una sucursal.")]
        public Sucursal Sucursal { set; get; }

        [Required(ErrorMessage = "Por favor seleccione una moneda.")]
        public Moneda Moneda { set; get; }

        [Required(ErrorMessage = "Por favor seleccione un estado.")]
        public Estado Estado { set; get; }

        //[DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Por favor ingrese un monto.")]
        public decimal Monto { set; get; }

        [Required(ErrorMessage = "Por favor ingrese una fecha.")]
        [MaxLength(10, ErrorMessage = "Por favor ingrese una fecha válida.")]
        [MinLength(10, ErrorMessage = "Por favor ingrese una fecha válida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { set; get; }


    }
}