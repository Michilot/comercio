using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EC.ElComercio.Models
{
    public class BancoModel
    {
        //[Required(ErrorMessage = "Por favor seleccione un banco.")]
        public int Id { set; get; }

        [Required(ErrorMessage = "Por favor ingrese un nombre.")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nombre { set; get; }

        [Required(ErrorMessage = "Por favor ingrese una dirección.")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Direccion { set; get; }

        [Required(ErrorMessage = "Por favor ingrese una fecha.")]
        [MaxLength(10, ErrorMessage = "Por favor ingrese una fecha válida.")]
        [MinLength(10, ErrorMessage = "Por favor ingrese una fecha válida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { set; get; }
    }
}