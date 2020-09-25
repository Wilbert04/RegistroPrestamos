using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamos.Models
{
    public class Prestamoss
    {

        [Key]

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, 1000000, ErrorMessage = "Este Id es incorrecto")]
        public int PrestamoId { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, 1000000, ErrorMessage = "Ingrese el Id de la persona")]
        public int PersonaId { get; set; }

        public string Concepto { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MinLength(1000, ErrorMessage = "Ingrese un monto correcto")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public decimal Balance { get; set; }

    }
}
