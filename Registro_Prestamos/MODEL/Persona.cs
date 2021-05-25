using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Prestamos.MODEL
{
    public class Persona
    {
        [Key]

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca el id de la persona")]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca el nombre de la persona")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca el numero telefonico de la persona")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca la cedula de la persona")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca la direccion de la persona")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca la fecha de nacimiento de la persona")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio, introduzca el balance del prestamo")]
        public float Balance { get; set; }
    }
}
