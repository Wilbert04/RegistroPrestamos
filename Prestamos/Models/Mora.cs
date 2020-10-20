using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamos.Models
{
    public class Mora
    {
        [Key]
        public int MoraId { get; set; }

        [Required(ErrorMessage = "DEBE INGRESAR UN PRESTMAO")]
        public int PrestamoId { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }


        [ForeignKey("MoraId")]
        public virtual List<MoraDetalle> MorasDetalles { get; set; }
    }
}
