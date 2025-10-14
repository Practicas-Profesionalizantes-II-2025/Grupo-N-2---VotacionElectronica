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
        private readonly SeguridadServicio _seguridad;
        private readonly IEleccionRepository _repoEleccion;


        public PersonaLogic(IPersonaRepository repositorio, SeguridadServicio seguridad, IEleccionRepository repoEleccion)
        {
            _repositorio = repositorio;
            _seguridad = seguridad;
            _repoEleccion = repoEleccion;
        }

        public async Task<List<VerDTO>> ObtenerTodas(int solicitanteId)
        {
            var solicitante = await _repositorio.ObtenerPorId(solicitanteId);
            if (solicitante == null)
                throw new InvalidOperationException("Usuario no encontrado");

            var personas = await _repositorio.ObtenerTodas();

            // 🕶️ Si no es SuperAdmin, filtra por las que él creó
            if (solicitante.Rol != "SuperAdmin")
                personas = personas.Where(p => p.CreadorId == solicitante.Id).ToList();

            return personas.Select(p => new VerDTO
            {
                Id = p.Id,
                NombrePersona = p.NombrePersona,
                ApellidoPersona = p.ApellidoPersona,
                Dni = p.NroIdentificacionPersona,
                Rol = p.Rol,
                Contrasenia = p.ContraseniaPersona,
                PrimerLogin = p.PrimerLogin
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
                Rol = persona.Rol,
                Contrasenia = persona.ContraseniaPersona,
                PrimerLogin = persona.PrimerLogin

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
                Rol = p.Rol,
                Contrasenia = p.ContraseniaPersona,
                PrimerLogin = p.PrimerLogin


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
                Rol = persona.Rol,
                Contrasenia = persona.ContraseniaPersona,
                PrimerLogin = persona.PrimerLogin

            };
        }

        public async Task Crear(CrearDTO dto, int creadorId)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Los datos de la persona son obligatorios.");

            ValidacionesNombres.ValidarCampoObligatorio(dto.NombrePersona, "Nombre");
            ValidacionesNombres.ValidarCampoObligatorio(dto.ApellidoPersona, "Apellido");
            ValidacionesNombres.ValidarCampoObligatorio(dto.TipoDocumentoPersona, "Tipo Documento");
            ValidacionesNombres.ValidarCampoObligatorio(dto.NroIdentificacionPersona, "Número de identificación");
            ValidacionesNombres.ValidarCampoObligatorio(dto.Rol, nameof(dto.Rol));

            ValidacionesNombres.ValidarSoloLetrasYEspacios(dto.NombrePersona, "Nombre");
            ValidacionesNombres.ValidarSoloLetrasYEspacios(dto.ApellidoPersona, "Apellido");

            var superAdminExistente = await _repositorio.ObtenerPorRol("SuperAdmin");
            if (dto.Rol == "SuperAdmin" && superAdminExistente != null)
                throw new InvalidOperationException("Ya existe un SuperAdmin. Solo puede haber uno.");
            var creador = await _repositorio.ObtenerPorId(creadorId);
            if (creador == null)
                throw new InvalidOperationException("El creador no existe.");

            var existente = await _repositorio.ObtenerPorDNI(dto.NroIdentificacionPersona);
            if (existente != null)
                throw new InvalidOperationException("Ya existe una persona con este número de identificación.");
            if (dto.Rol == "Administrador" && creador.Rol != "SuperAdmin")
                throw new UnauthorizedAccessException("Solo el SuperAdmin puede crear administradores.");

            if (dto.Rol == "SuperAdmin" && creador.Rol != "SuperAdmin")
                throw new UnauthorizedAccessException("Solo el SuperAdmin puede crear otro SuperAdmin (y solo si no existe).");

            if (!dto.NroIdentificacionPersona.All(char.IsDigit))
                throw new ArgumentException("El número de identificación debe contener solo números.");
            if (dto.TipoDocumentoPersona == "DNI")
            {
                if (dto.NroIdentificacionPersona.Length != 8 || !dto.NroIdentificacionPersona.All(char.IsDigit))
                    throw new InvalidOperationException("El DNI debe tener exactamente 8 dígitos numéricos.");
            }
            else if (dto.TipoDocumentoPersona == "CUIL")
            {
                if (dto.NroIdentificacionPersona.Length != 11 || !dto.NroIdentificacionPersona.All(char.IsDigit))
                    throw new InvalidOperationException("El CUIL debe tener exactamente 11 dígitos numéricos.");

                if (!dto.NroIdentificacionPersona.StartsWith("20") &&
                    !dto.NroIdentificacionPersona.StartsWith("23") &&
                    !dto.NroIdentificacionPersona.StartsWith("27") &&
                    !dto.NroIdentificacionPersona.StartsWith("30"))
                    throw new InvalidOperationException("El CUIL debe comenzar con 20, 23, 27 o 30.");
            }
            else if (dto.TipoDocumentoPersona == "Libreta de Enrolamiento")
            {
                if (dto.NroIdentificacionPersona.Length < 6 || dto.NroIdentificacionPersona.Length > 8)
                    throw new InvalidOperationException("La Libreta de Enrolamiento debe tener entre 6 y 8 dígitos.");

                if (!dto.NroIdentificacionPersona.All(char.IsDigit))
                    throw new InvalidOperationException("La Libreta de Enrolamiento debe contener solo números.");
            }

            var persona = new Persona
            {
                NombrePersona = dto.NombrePersona,
                ApellidoPersona = dto.ApellidoPersona,
                NroIdentificacionPersona = dto.NroIdentificacionPersona,
                Rol = dto.Rol,
                TipoDocumentoPersona = dto.TipoDocumentoPersona,
                ContraseniaPersona = _seguridad.HashContrasenia(dto.NroIdentificacionPersona),
                CreadorId = creadorId,
                PrimerLogin = true
            };

            await _repositorio.Crear(persona);
        }

        public async Task CambiarContrasenia(int id, string nuevaContrasenia)
        {
            var persona = await _repositorio.ObtenerPorId(id);
            if (persona == null)
                throw new Exception("Persona no encontrada");

            // Comparamos si la nueva contraseña es igual a la anterior
            if (_seguridad.VerificarContrasenia(nuevaContrasenia, persona.ContraseniaPersona))
                throw new Exception("La nueva contraseña no puede ser igual a la anterior.");

            //  Si es diferente, generar nuevo hash y guardar
            persona.ContraseniaPersona = _seguridad.HashContrasenia(nuevaContrasenia);
            persona.PrimerLogin = false;

            await _repositorio.Actualizar(persona);

        }

        public async Task Actualizar(int id, ModificarDTO dto)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la persona es inválido.", nameof(id));

            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Los datos de la persona son obligatorios.");

            ValidacionesNombres.ValidarCampoObligatorio(dto.NombrePersona, "Nombre");
            ValidacionesNombres.ValidarCampoObligatorio(dto.ApellidoPersona, "Apellido");
            ValidacionesNombres.ValidarSoloLetrasYEspacios(dto.NombrePersona, "Nombre");
            ValidacionesNombres.ValidarSoloLetrasYEspacios(dto.ApellidoPersona, "Apellido");

            var persona = await _repositorio.ObtenerPorId(id);
            if (persona == null)
                throw new InvalidOperationException("Persona no encontrada.");

            persona.NombrePersona = dto.NombrePersona.Trim();
            persona.ApellidoPersona = dto.ApellidoPersona.Trim();

            // 🔹 Validación de contraseña distinta
            if (!string.IsNullOrWhiteSpace(dto.ContraseniaPersona))
            {
                if (_seguridad.VerificarContrasenia(dto.ContraseniaPersona, persona.ContraseniaPersona))
                    throw new ArgumentException("La nueva contraseña no puede ser igual a la anterior");

                persona.ContraseniaPersona = _seguridad.HashContrasenia(dto.ContraseniaPersona);
            }

            persona.PrimerLogin = dto.PrimerLogin;

            await _repositorio.Actualizar(persona);
        }


        public async Task Eliminar(int id)
        {
            var persona = await _repositorio.ObtenerPorId(id);


            if (id <= 0)
                throw new ArgumentException("El ID de la persona es inválido.", nameof(id));

            if (persona == null)
                throw new InvalidOperationException("No se puede eliminar: la persona no existe.");

            await _repositorio.Eliminar(id);
        }


        public async Task<VerDTO> Autenticar(string dni, string contrasenia)
        {
            if (string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(contrasenia))
                throw new ArgumentException("DNI y contraseña son obligatorios.");

            var persona = await _repositorio.ObtenerPorDNI(dni);
            if (persona == null)
                throw new InvalidOperationException("Persona no encontrada.");

            if (!_seguridad.VerificarContrasenia(contrasenia, persona.ContraseniaPersona))
                throw new InvalidOperationException("Contraseña incorrecta.");

            return new VerDTO
            {
                Id = persona.Id,
                NombrePersona = persona.NombrePersona,
                ApellidoPersona = persona.ApellidoPersona,
                Dni = persona.NroIdentificacionPersona,
                Rol = persona.Rol,
                Contrasenia = persona.ContraseniaPersona,
                PrimerLogin = persona.PrimerLogin
            };
        }



        public async Task<List<Eleccion>> ObtenerEleccionesAutorizadas(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI es obligatorio.", nameof(dni));

            return await _repositorio.ObtenerEleccionesAutorizadas(dni);
        }
        public async Task<List<Eleccion>> ObtenerEleccionesAsignadas(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI es obligatorio.", nameof(dni));

            var persona = await _repositorio.ObtenerPorDNI(dni);
            if (persona == null)
                throw new InvalidOperationException("No se encontró una persona con ese DNI.");
            var elecciones = await _repoEleccion.ObtenerTodas();

            if (persona.Rol == "SuperAdmin")
            {
                // SuperAdmin ve todas las elecciones
                return elecciones;
            }

            if (persona.Rol == "Administrador")
            {
                // Admin ve solo las que él creó
                elecciones = elecciones.Where(e => e.CreadorId == persona.Id).ToList();
                return elecciones;
            }

            // Cualquier otro rol: solo las asignadas
            return await _repositorio.ObtenerEleccionesAsignadas(dni);
        }



        public async Task<List<VerDTO>> ObtenerPersonasNoAsignadas(int eleccionId, int solicitanteId)
        {
            var solicitante = await _repositorio.ObtenerPorId(solicitanteId);
            if (solicitante == null)
                throw new InvalidOperationException("Usuario no encontrado");

            var personas = solicitante.Rol == "SuperAdmin"
                ? await _repositorio.ObtenerPersonasNoAsignadas(eleccionId, null) // traer todas
                : await _repositorio.ObtenerPersonasNoAsignadas(eleccionId, solicitanteId);

            return personas.Select(p => new VerDTO
            {
                Id = p.Id,
                NombrePersona = p.NombrePersona,
                ApellidoPersona = p.ApellidoPersona,
                Dni = p.NroIdentificacionPersona,
                Rol = p.Rol
            }).ToList();
        }


    }
}


