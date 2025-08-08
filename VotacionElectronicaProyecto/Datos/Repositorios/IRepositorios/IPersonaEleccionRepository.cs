using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios.IRepositorios
{
    public interface IPersonaEleccionRepository
    {
        Task<PersonaEleccion> ObtenerPorPersonaYEleccion(int personaId, int eleccionId);
        Task Actualizar(PersonaEleccion personaEleccion);

    }
}
