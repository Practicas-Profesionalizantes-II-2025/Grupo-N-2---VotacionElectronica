using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProyecto.Models.Eleccion
{
    public class AsignarPersonaEleccionDTO
    {
        public int PersonaId { get; set; }
        public int EleccionId { get; set; }
        public bool Autorizada { get; set; } = true; // Se puede usar true al crear la relación
    }

}
