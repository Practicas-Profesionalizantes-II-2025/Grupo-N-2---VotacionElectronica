using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Resultado : EntityBase
    {

        public int EleccionId { get; set; } // Agregar esta propiedad para referenciar a Eleccion
        public Eleccion Eleccion { get; set; }
        public int CantidadVotos {  get; set; }
        public ICollection<Voto> Votos { get; set; }
    }
}
