using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProyecto.Models.Lista
{
    public class CrearDTO
    {
        
        public string NombreLista { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string DescripcionLista { get; set; }
                
    }
}

