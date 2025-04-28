using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class PersonaEleccion
    {
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
        public int EleccionId { get; set; }
        public Eleccion Eleccion { get; set; }
        public bool Autorizada { get; set; } = true;// Indica si la persona está autorizada a votar en esa elección
    }

}
