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

        

        public string NroIdentificacionPersona { get; set; }

        
        public string? ApellidoPersona { get; set; }


        public string TipoDocumentoPersona { get; set; }

        public string Rol { get; set; }

        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        
    }
}