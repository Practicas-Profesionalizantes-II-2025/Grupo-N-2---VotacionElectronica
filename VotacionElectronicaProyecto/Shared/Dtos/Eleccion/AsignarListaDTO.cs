using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Eleccion
{
    public class AsignarListaDTO
    {
        public int EleccionId { get; set; }
        public int ListaId { get; set; }
        public required string Descripcion { get; set; }
    }

}
