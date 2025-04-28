using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Lista
{
    public class CrearDTO
    {
        [MaxLength(
            Shared.Entities.Lista.LengthNombre,
            ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
        )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreLista { get; set; }

        [MaxLength(
            Shared.Entities.Lista.LengthDescripcion,
            ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
        )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string DescripcionLista { get; set; }
                
    }
}

