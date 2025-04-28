using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Persona
{
    public class ModificarDTO
    {
        [MaxLength(
            Shared.Entities.Persona.LengthNombrePersona,
            ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
        )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombrePersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ApellidoPersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ContraseniaPersona { get; set; }


    }
}
