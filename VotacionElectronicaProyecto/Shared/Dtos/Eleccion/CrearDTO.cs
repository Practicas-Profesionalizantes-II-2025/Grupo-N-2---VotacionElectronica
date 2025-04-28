using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Eleccion
{
    public class CrearDTO
    {
        [MaxLength(
            Shared.Entities.Eleccion.LengthNombreEleccion,
            ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
        )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreEleccion { get; set; }

        [MaxLength(
            Shared.Entities.Eleccion.LengthDescripcionEleccion,
            ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
        )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string DescripcionEleccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CantidadListas { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public DateTime FechaInicioEleccion { get; set; } 

        public DateTime FechaFinEleccion { get; set; }
    }
}
