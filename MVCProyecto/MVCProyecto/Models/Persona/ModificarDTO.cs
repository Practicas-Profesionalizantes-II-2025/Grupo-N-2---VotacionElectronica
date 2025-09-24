using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProyecto.Models.Persona
{
    public class ModificarDTO
    {

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombrePersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ApellidoPersona { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ContraseniaPersona { get; set; }
        public bool PrimerLogin { get; set; } // se marca en false al cambiar contraseña


    }
}
