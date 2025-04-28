using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Candidatos : EntityBase
    {        
        public const int LengthNombreCandidato = 30;
        public const int LengthPuestoCandidato = 20;
        public string NombreCandidato { get; set; }

        public string PuestoCandidato { get; set; }

        public int IdLista { get; set; }
        public Lista Lista { get; set; }
    }
}
