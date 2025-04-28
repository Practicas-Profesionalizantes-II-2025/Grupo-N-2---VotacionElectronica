using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Lista : EntityBase
    {
        public const int LengthNombre = 20;
        public const int LengthDescripcion = 120;

        [MaxLength(
           LengthNombre,
           ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
       )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreLista { get; set; }
        [MaxLength(
           LengthDescripcion,
           ErrorMessage = "El campo {0} no puede tener más de {1} caracteres."
       )]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string DescripcionLista { get; set; }
        public int CantidadIntegrantes { get; set; }

        public int EleccionId { get; set; }

        public ICollection<Voto> Votos { get; set; }

        public ICollection <Candidatos> Candidatos{ get; set; }

        public ICollection<Eleccion> Elecciones { get; set; }

    }
}


