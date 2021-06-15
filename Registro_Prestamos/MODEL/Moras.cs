using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Prestamos.MODEL
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca el total de la Mora")]
        public float Total { get; set; }
        public List<MorasDetalle> Detalle { get; set; }

        public Moras()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            Detalle = new List<MorasDetalle>();
        }
    }
}
