using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Eleccion
{
    public class ModificarDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreEleccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string DescripcionEleccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CantidadListas { get; set; }
        public DateTime FechaFinEleccion { get; set; }
        public DateTime FechaInicioEleccion { get; set; }

    }
}
