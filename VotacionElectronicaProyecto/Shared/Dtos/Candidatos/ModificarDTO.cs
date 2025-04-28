using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Candidatos
{
    public class ModificarDTO
    {

        [MaxLength(
            Shared.Entities.Candidatos.LengthNombreCandidato,
            ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
        )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreCandidato { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PuestoCandidato { get; set; }

    }
}
