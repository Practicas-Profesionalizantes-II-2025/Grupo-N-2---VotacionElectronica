using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProyecto.Models.Persona
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El DNI es obligatorio")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }
    }
}
