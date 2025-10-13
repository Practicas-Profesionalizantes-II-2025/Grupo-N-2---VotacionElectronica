using Shared.Dtos.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica.ILogica
{
    public interface IPersonaLogic
    {
        Task<List<VerDTO>> ObtenerTodas(int id);
        Task<VerDTO> ObtenerPorId(int id);
        Task<List<VerDTO>> ObtenerPorNombre(string nombre);

        Task<VerDTO> ObtenerPorDNI(string dni);
        Task Crear(CrearDTO dto, int creadorId);
        Task Actualizar(int id, ModificarDTO dto);
        Task Eliminar(int id);
        Task<VerDTO> Autenticar(string dni, string contrasenia);
        Task<List<Shared.Entities.Eleccion>> ObtenerEleccionesAutorizadas(string dni);
        Task<List<Shared.Entities.Eleccion>> ObtenerEleccionesAsignadas(string dni);


        Task CambiarContrasenia(int personaId, string nuevaContrasenia);
        Task<List<VerDTO>> ObtenerPersonasNoAsignadas(int eleccionId, int solicitanteId);



    }
}
