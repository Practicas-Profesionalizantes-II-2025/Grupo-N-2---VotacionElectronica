using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios.IRepositorios
{
    public interface IPersonaRepository
    {
        Task<List<Persona>> ObtenerTodas();

        Task<Persona> ObtenerPorId(int id);
        Task<List<Persona>> ObtenerPorNombre(string nombre);
        Task<Persona> ObtenerPorRol(string rol);


        Task<Persona> ObtenerPorDNI(string dni);
        Task Crear(Persona persona);
        Task Actualizar(Persona persona);
        Task Eliminar(int id);
        Task<List<Eleccion>> ObtenerEleccionesAutorizadas(string dni);
        Task<List<Eleccion>> ObtenerEleccionesAsignadas(string dni);

        Task<List<Persona>> ObtenerPersonasNoAsignadas(int eleccionId, int? solicitanteId);


    }
}
