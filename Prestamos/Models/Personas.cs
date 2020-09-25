using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamos.Models
{
    public class Personas
    {
        [Key]
        [Required(ErrorMessage = "Es obligatorio llenar este campo")]
        [Range(0, 1000000, ErrorMessage = "Este Id no es correcto")]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Es obligatorio llenar este campo")]
        [MinLength(3, ErrorMessage = "Nombre muy corto")]
        public string Nombre { get; set; }

        [Required]
        [Phone]
        [MaxLength(10, ErrorMessage = "Telefono muy corto")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Es obligatorio llenar este campo")]
        [MinLength(11, ErrorMessage = "Cedula demasiado corta")]
        [MaxLength(11, ErrorMessage = "Ha excedido la cantidad de numeros permitidos")]
        public string Cedula { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public decimal Balance { get; set; }
    }
}
