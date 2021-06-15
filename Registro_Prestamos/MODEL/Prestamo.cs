using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Prestamos.MODEL
{
    public class Prestamo
    {
        [Key]
        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca el id del prestamo")]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca la fecha del prestamo")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca el id de la persona")]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca el concepto del prestamo")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca el monto del prestamo")]
        public float Monto { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca el balance del prestamo")]
        public float Balance { get; set; }
        public List<MorasDetalle> Detalle { get; set; }
    }
}
