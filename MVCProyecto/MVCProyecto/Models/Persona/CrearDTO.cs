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
        public string NombrePersona { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NroIdentificacionPersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? ApellidoPersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ContraseniaPersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TipoDocumentoPersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Rol { get; set; }

        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
}

