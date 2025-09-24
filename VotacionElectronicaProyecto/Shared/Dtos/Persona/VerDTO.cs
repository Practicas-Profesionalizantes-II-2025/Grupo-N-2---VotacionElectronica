using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Persona
{
    public class VerDTO
    {
        public int Id { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string Rol { get; set; }
        public string Dni { get; set; }
        public string Contrasenia { get; set; }
        public bool PrimerLogin { get; set; } 

    }

}
