using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProyecto.Models.Eleccion
{
    public class AsignarPersonaEleccionDTO
    {
        public List<int> PersonaIds { get; set; } = new();
        public int EleccionId { get; set; }
        public bool Autorizada { get; set; } = true; // Se puede usar true al crear la relación

        public IEnumerable<SelectListItem>? Personas { get; set; }
        public IEnumerable<SelectListItem>? Elecciones { get; set; }


    }

}
