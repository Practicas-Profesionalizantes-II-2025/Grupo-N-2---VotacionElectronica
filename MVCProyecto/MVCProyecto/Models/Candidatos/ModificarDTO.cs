using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProyecto.Models.Candidatos
{
    public class ModificarDTO
    {

        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreCandidato { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PuestoCandidato { get; set; }

    }
}
