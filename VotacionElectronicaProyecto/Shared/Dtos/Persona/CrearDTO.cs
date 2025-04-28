using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Persona
{
    public class CrearDTO
    {

        [MaxLength(
            Shared.Entities.Persona.LengthNombrePersona,
            ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
        )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombrePersona { get; set; }

        [MaxLength(
            Shared.Entities.Persona.LengthNroIdentificacionPersona,
            ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
        )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        
        [StringLength(
            8,
            MinimumLength = 7,
            ErrorMessage = "El campo {0} debe tener entre {7} y {8} caracteres."
        )]
        public string NroIdentificacionPersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? ApellidoPersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ContraseniaPersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TipoDocumentoPersona { get; set; }
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
}

