using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Persona
{
    public class CrearDTO : IValidatableObject

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

        public string NroIdentificacionPersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? ApellidoPersona { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TipoDocumentoPersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Rol { get; set; }

        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoDocumentoPersona == "DNI")
            {
                if (NroIdentificacionPersona.Length < 7 || NroIdentificacionPersona.Length > 8)
                    yield return new ValidationResult("El DNI debe tener entre 7 y 8 caracteres ", new[] { nameof(NroIdentificacionPersona) });
            }
            else if (TipoDocumentoPersona == "CUIL")
            {
                if (NroIdentificacionPersona.Length != 11)
                    yield return new ValidationResult("El CUIL debe tener 11 caracteres ", new[] { nameof(NroIdentificacionPersona) });
            }
            else if (TipoDocumentoPersona == "Libreta de Enrolamiento")
            {
                if (NroIdentificacionPersona.Length != 8)
                    yield return new ValidationResult("La Libreta de Enrolamiento debe tener 8 caracteres ", new[] { nameof(NroIdentificacionPersona) });
            }
        }
    }
}