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
            if (id <= 0)
                throw new ArgumentException("El ID es inválido.", nameof(id));


            var persona = await _repositorio.ObtenerPorId(id);
            if (persona == null)
                throw new InvalidOperationException("Persona no encontrada.");

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
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));

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
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI es obligatorio.", nameof(dni));

            var persona = await _repositorio.ObtenerPorDNI(dni);
            if (persona == null)
                throw new InvalidOperationException("Persona no encontrada.");
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
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Los datos de la persona son obligatorios.");

            if (string.IsNullOrWhiteSpace(dto.NombrePersona))
                throw new ArgumentException("El nombre de la persona es obligatorio.", nameof(dto.NombrePersona));

            if (string.IsNullOrWhiteSpace(dto.ApellidoPersona))
                throw new ArgumentException("El apellido de la persona es obligatorio.", nameof(dto.ApellidoPersona));

            if (string.IsNullOrWhiteSpace(dto.TipoDocumentoPersona))
                throw new ArgumentException("El tipo de documento es obligatorio.", nameof(dto.TipoDocumentoPersona));

            if (string.IsNullOrWhiteSpace(dto.NroIdentificacionPersona))
                throw new ArgumentException("El número de identificación es obligatorio.", nameof(dto.NroIdentificacionPersona));

            if (string.IsNullOrWhiteSpace(dto.Rol))
                throw new ArgumentException("El rol es obligatorio.", nameof(dto.Rol));

            var existente = await _repositorio.ObtenerPorDNI(dto.NroIdentificacionPersona);
            if (existente != null)
                throw new InvalidOperationException("Ya existe una persona con este número de identificación.");

            var persona = new Persona
            {
                NombrePersona = dto.NombrePersona.Trim(),
                ApellidoPersona = dto.ApellidoPersona.Trim(),
                TipoDocumentoPersona = dto.TipoDocumentoPersona.Trim(),
                NroIdentificacionPersona = dto.NroIdentificacionPersona.Trim(),
                Rol = dto.Rol.Trim()
            };


            if (dto.Rol.Equals("Votante", StringComparison.OrdinalIgnoreCase))
            {
                var seguridadServicio = new SeguridadServicio();
                persona.ContraseniaPersona = seguridadServicio.CrearContrasenia(dto.NroIdentificacionPersona);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(dto.ContraseniaPersona))
                    throw new ArgumentException("La contraseña es obligatoria para roles distintos de Votante.", nameof(dto.ContraseniaPersona));

                persona.ContraseniaPersona = dto.ContraseniaPersona;
            }

            await _repositorio.Crear(persona);
        }

        public async Task Actualizar(int id, ModificarDTO dto)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la persona es inválido.", nameof(id));

            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Los datos de la persona son obligatorios.");

            if (string.IsNullOrWhiteSpace(dto.NombrePersona))
                throw new ArgumentException("El nombre de la persona es obligatorio.", nameof(dto.NombrePersona));

            if (string.IsNullOrWhiteSpace(dto.ApellidoPersona))
                throw new ArgumentException("El apellido de la persona es obligatorio.", nameof(dto.ApellidoPersona));

            if (string.IsNullOrWhiteSpace(dto.ContraseniaPersona))
                throw new ArgumentException("La contraseña es obligatoria.", nameof(dto.ContraseniaPersona));

            var persona = await _repositorio.ObtenerPorId(id);
            if (persona == null)
                throw new InvalidOperationException("Persona no encontrada.");

            persona.NombrePersona = dto.NombrePersona.Trim();
            persona.ApellidoPersona = dto.ApellidoPersona.Trim();
            persona.ContraseniaPersona = dto.ContraseniaPersona;

            await _repositorio.Actualizar(persona);
        }


        public async Task Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la persona es inválido.", nameof(id));

            var persona = await _repositorio.ObtenerPorId(id);
            if (persona == null)
                throw new InvalidOperationException("No se puede eliminar: la persona no existe.");

            await _repositorio.Eliminar(id);
        }


        public async Task<VerDTO> AutenticarPorContrasenia(string contrasenia)
        {
            if (string.IsNullOrWhiteSpace(contrasenia))
                throw new ArgumentException("La contraseña es obligatoria.", nameof(contrasenia));

            var persona = await _repositorio.AutenticarPorContrasenia(contrasenia);
            if (persona == null)
                throw new InvalidOperationException("No se encontró una persona con la contraseña proporcionada.");
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
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI es obligatorio.", nameof(dni));

            return await _repositorio.ObtenerEleccionesAutorizadas(dni);
        }

    }
}


