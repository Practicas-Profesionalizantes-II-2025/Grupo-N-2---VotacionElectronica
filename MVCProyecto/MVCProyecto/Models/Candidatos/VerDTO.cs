using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProyecto.Models.Candidatos
{
    public class VerDTO
    {
        public int Id { get; set; }
        public string NombreCandidato { get; set; }
        public string PuestoCandidato { get; set; }
        public int IdLista { get; set; }
        public string? NombreLista { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
