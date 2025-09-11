using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProyecto.Models.Voto
{
        public class CrearDTO
        {
            public int EleccionId { get; set; }
            public int ListaId { get; set; }
            public int PersonaId { get; set; }
        }
}

