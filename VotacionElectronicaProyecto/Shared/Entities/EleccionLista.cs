using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class EleccionLista : EntityBase
    {        
        public int IdEleccion {  get; set; }
        public int IdLista { get; set; }

        public string DescripcionEleccionLista { get; set; }
        public Eleccion Eleccion { get; set; }
        public Lista Lista { get; set; }

    }
}
