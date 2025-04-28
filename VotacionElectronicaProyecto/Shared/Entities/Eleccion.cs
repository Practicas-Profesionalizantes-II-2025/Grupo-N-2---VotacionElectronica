using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Eleccion : EntityBase
    {
        public const int LengthNombreEleccion = 40;
        public const int LengthDescripcionEleccion = 150;
        public string NombreEleccion { get; set; }
        public string DescripcionEleccion { get; set; }
        public int CantidadListas { get; set; }
        public DateTime FechaFinEleccion { get; set; }
        public DateTime FechaInicioEleccion { get; set; }
        public ICollection<Voto> Votos { get; set; }
        public ICollection<Lista> Listas { get; set; }
        public ICollection<PersonaEleccion> PersonaElecciones { get; set; }



    }
}
