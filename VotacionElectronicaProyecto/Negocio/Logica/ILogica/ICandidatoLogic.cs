using Shared.Dtos.Candidatos;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica.ILogica
{
    public interface ICandidatoLogic
    {
        Task<List<VerDTO>> ObtenerCandidatos();
        Task<VerDTO> ObtenerCandidatoPorId(int id);
        Task<List<VerDTO>> ObtenerCandidatosPorNombre(string nombre);
        Task CrearCandidato(CrearDTO dto);
        Task ActualizarCandidato(int id, ModificarDTO dto);
        Task EliminarCandidato(int id);
        Task<List<Candidatos>> ObtenerPorLista(int listaId);


    }
}
