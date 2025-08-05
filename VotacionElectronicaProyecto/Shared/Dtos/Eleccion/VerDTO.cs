using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Eleccion
{
    public class VerDTO
    {
        public int Id { get; set; }
        public string NombreEleccion { get; set; }
        public string DescripcionEleccion { get; set; }
        public int CantidadListas { get; set; }
        public DateTime? FechaInicioEleccion { get; set; }
        public DateTime? FechaFinEleccion { get; set; }
        public DateTime CreatedDate { get; set; }  
        public DateTime UpdatedDate { get; set; } 

        // public List<ListaDTO> Listas { get; set; }

    }
}
