using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProyecto.Models.Candidatos
{
    public class CrearDTO
    {
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreCandidato { get; set; }


        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? PuestoCandidato { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int IdLista { get; set; }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}

