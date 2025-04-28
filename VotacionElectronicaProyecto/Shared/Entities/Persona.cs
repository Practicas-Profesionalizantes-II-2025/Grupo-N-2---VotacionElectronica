using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Persona : EntityBase
    {

        public const int LengthNombrePersona = 20;
        public const int LengthNroIdentificacionPersona = 8;
        public const int LengthApellidoPersona = 20;
        public const int LengthContraseniaPersona = 8;
        public int Id { get; set; }
        public string NroIdentificacionPersona { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string ContraseniaPersona { get; set; }
        public string TipoDocumentoPersona { get; set; }
        public ICollection<PersonaEleccion> PersonaElecciones { get; set; }

    }
}
