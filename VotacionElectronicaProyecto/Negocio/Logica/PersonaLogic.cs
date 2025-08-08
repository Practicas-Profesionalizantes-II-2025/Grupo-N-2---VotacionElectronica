using Datos.Repositorios.IRepositorios;
using Negocio.Logica.ILogica;
using Shared.Dtos.Persona;
using Shared.Entities;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica
{
    public class PersonaLogic : IPersonaLogic
    {
        private readonly IPersonaRepository _repositorio;

        public PersonaLogic(IPersonaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<VerDTO>> ObtenerTodas()
        {
            var personas = await _repositorio.ObtenerTodas();
            return personas.Select(p => new VerDTO
            {
                Id = p.Id,
                NombrePersona = p.NombrePersona,
                ApellidoPersona = p.ApellidoPersona,
                Dni = p.NroIdentificacionPersona,
                Rol = p.Rol
            }).ToList();
        }

        public async Task<VerDTO> ObtenerPorId(int id)
        {
            var persona = await _repositorio.ObtenerPorId(id);
            if (persona == null) return null;
            return new VerDTO
            {
                Id = persona.Id,
                NombrePersona = persona.NombrePersona,
                ApellidoPersona = persona.ApellidoPersona,
                Dni = persona.NroIdentificacionPersona,
                Rol = persona.Rol
            };
        }

        public async Task<List<VerDTO>> ObtenerPorNombre(string nombre)
        {
            var personas = await _repositorio.ObtenerPorNombre(nombre);
            return personas.Select(p => new VerDTO
            {
                Id = p.Id,
                NombrePersona = p.NombrePersona,
                ApellidoPersona = p.ApellidoPersona,
                Dni = p.NroIdentificacionPersona,
                Rol = p.Rol
            }).ToList();
        }

        public async Task<VerDTO> ObtenerPorDNI(string dni)
        {
            var persona = await _repositorio.ObtenerPorDNI(dni);
            if (persona == null) return null;
            return new VerDTO
            {
                Id = persona.Id,
                NombrePersona = persona.NombrePersona,
                ApellidoPersona = persona.ApellidoPersona,
                Dni = persona.NroIdentificacionPersona,
                Rol = persona.Rol
            };
        }

        public async Task Crear(CrearDTO dto)
        {
            var persona = new Persona
            {
                NombrePersona = dto.NombrePersona,
                ApellidoPersona = dto.ApellidoPersona,
                TipoDocumentoPersona = dto.TipoDocumentoPersona,
                NroIdentificacionPersona = dto.NroIdentificacionPersona,
                Rol = dto.Rol
            };

            if (dto.Rol == "Votante")
            {
                var seguridadServicio = new SeguridadServicio();
                persona.ContraseniaPersona = seguridadServicio.CrearContrasenia(dto.NroIdentificacionPersona);
            }
            else
            {
                persona.ContraseniaPersona = dto.ContraseniaPersona;
            }

            await _repositorio.Crear(persona);
        }

        public async Task Actualizar(int id, ModificarDTO dto)
        {
            var persona = await _repositorio.ObtenerPorId(id);
            if (persona == null) throw new Exception("Persona no encontrada");

            persona.NombrePersona = dto.NombrePersona;
            persona.ApellidoPersona = dto.ApellidoPersona;
            persona.ContraseniaPersona = dto.ContraseniaPersona;
            await _repositorio.Actualizar(persona);
        }

        public async Task Eliminar(int id)
        {
            await _repositorio.Eliminar(id);
        }

        public async Task<VerDTO> AutenticarPorContrasenia(string contrasenia)
        {
            var persona = await _repositorio.AutenticarPorContrasenia(contrasenia);
            if (persona == null) return null;
            return new VerDTO
            {
                Id = persona.Id,
                NombrePersona = persona.NombrePersona,
                ApellidoPersona = persona.ApellidoPersona,
                Dni = persona.NroIdentificacionPersona,
                Rol = persona.Rol
            };
        }

        public async Task<List<Eleccion>> ObtenerEleccionesAutorizadas(string dni)
        {
            return await _repositorio.ObtenerEleccionesAutorizadas(dni);
        }

    }
}
