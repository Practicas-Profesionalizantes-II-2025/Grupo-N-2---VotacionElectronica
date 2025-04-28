using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negocio.CasosDeUso
{
    public static class Persona
    {
        public static async Task Crear(Shared.Dtos.Persona.CrearDTO persona)
        {
            ArgumentNullException.ThrowIfNull(persona);

            // Lista para acumular errores
            var errores = ValidarCrear(persona);

            // Si hay errores, lanzar una excepción
            if (errores.Any())
            {
                throw new ArgumentException(string.Join(" ", errores));
            }

            // Validación del DNI
            if (persona.NroIdentificacionPersona.Length < 7 || persona.NroIdentificacionPersona.Length > 8)
            {
                errores.Add("El DNI debe tener entre 7 y 8 caracteres.");
            }

            // Verificar si el DNI ya está registrado
            var personaExistente = await Negocio.Repositorio.Persona.GetByDni(persona.NroIdentificacionPersona);
            if (personaExistente != null)
            {
                errores.Add("El DNI ya está registrado para otra persona.");
            }

            // Si hay errores, lanzar una excepción
            if (errores.Any())
            {
                throw new ArgumentException(string.Join(" ", errores));
            }

            await Repositorio.Persona.Create(persona);
        }

        public static async Task Modificar(int id, Shared.Dtos.Persona.ModificarDTO personaModificar)
        {
            ArgumentNullException.ThrowIfNull(personaModificar);
            if (personaModificar.NombrePersona == null)
                throw new ArgumentNullException(nameof(personaModificar.NombrePersona));

            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            // Validar los datos de la persona a modificar
            var errores = ValidarModificar(personaModificar);

            // Si hay errores, lanzar una excepción
            if (errores.Any())
            {
                throw new ArgumentException(string.Join(" ", errores));
            }

            await Repositorio.Persona.Update(id, personaModificar);
        }

        public static async Task<List<Shared.Entities.Persona>> ObtenerTodo()
        {
            return await Repositorio.Persona.Get();
        }

        public static async Task<Shared.Entities.Persona?> ObtenerPorId(int id)
        {
            return await Repositorio.Persona.Get(id);
        }

        public static async Task<List<Shared.Entities.Persona>?> ObtenerPorNombre(string nombre)
        {
            return await Repositorio.Persona.Get(nombre);
        }

        public static async Task Borrar(int id)
        {
            await Repositorio.Persona.Delete(id);
        }

        public static async Task<Shared.Entities.Persona?> AutenticarPorContraseña(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            return await Repositorio.Persona.GetByPassword(password);
        }

        public static async Task<Shared.Entities.Persona?> ObtenerPorDni(string dni)
        {
            if (string.IsNullOrEmpty(dni))
                throw new ArgumentNullException(nameof(dni));

            return await Repositorio.Persona.GetByDni(dni);
        }

        public static async Task<string> CrearPersonaConContrasenia(string numeroIdentificacion)
        {
            var seguridadServicio = new SeguridadServicio();
            string contrasenia = seguridadServicio.CrearContrasenia(numeroIdentificacion);
            return contrasenia;
        }

        public static async Task<List<Shared.Entities.Eleccion>> ObtenerEleccionesAutorizadas(string dni)
        {
            return await Repositorio.Persona.GetEleccionesAutorizadas(dni);
        }

        // Método de validación para crear
        private static List<string> ValidarCrear(Shared.Dtos.Persona.CrearDTO persona)
        {
            var errores = new List<string>();

            // Validar NombrePersona
            if (string.IsNullOrWhiteSpace(persona.NombrePersona))
            {
                errores.Add("El campo Nombre/s es obligatorio.");
            }
            else if (!persona.NombrePersona.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                errores.Add("El campo Nombre/s solo debe contener letras y espacios.");
            }

            // Validar ApellidoPersona
            if (string.IsNullOrWhiteSpace(persona.ApellidoPersona))
            {
                errores.Add("El campo Apellido/s es obligatorio.");
            }
            else if (!persona.ApellidoPersona.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                errores.Add("El campo Apellido/s solo debe contener letras y espacios.");
            }

            // Validar NroIdentificacionPersona
            if (string.IsNullOrWhiteSpace(persona.NroIdentificacionPersona))
            {
                errores.Add("El campo Número es obligatorio.");
            }
            else if (!persona.NroIdentificacionPersona.All(char.IsDigit))
            {
                errores.Add("El campo Número solo debe contener dígitos.");
            }

            // Validar TipoDocumentoPersona
            if (string.IsNullOrWhiteSpace(persona.TipoDocumentoPersona))
            {
                errores.Add("El campo Tipo Documento es obligatorio.");
            }

            return errores;
        }

        // Método de validación para modificar
        private static List<string> ValidarModificar(Shared.Dtos.Persona.ModificarDTO personaModificar)
        {
            var errores = new List<string>();

            // Validar NombrePersona
            if (string.IsNullOrWhiteSpace(personaModificar.NombrePersona))
            {
                errores.Add("El campo Nombre/s es obligatorio.");
            }
            else if (!personaModificar.NombrePersona.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                errores.Add("El campo Nombre/s solo debe contener letras y espacios.");
            }

            // Validar ApellidoPersona
            if (string.IsNullOrWhiteSpace(personaModificar.ApellidoPersona))
            {
                errores.Add("El campo Apellido/s es obligatorio.");
            }
            else if (!personaModificar.ApellidoPersona.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                errores.Add("El campo Apellido/s solo debe contener letras y espacios.");
            }

            return errores;
        }
    }
}
