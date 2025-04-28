using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Voto : EntityBase
    {
        public DateTime FechaVoto { get; set; }
        public DateTime HoraVoto { get; set; }

        public int EleccionId { get; set; }
        public Eleccion Eleccion { get; set; }

        public int ListaId { get; set; }
        public Lista Lista { get; set; }
        public int? ResultadoId { get; set; } // Hacerlo nullable
        public Resultado Resultado { get; set; }
    }
}
