using Shared.Dtos.Eleccion;

namespace Negocio.CasosDeUso
{
    public static class Eleccion
    {
        public static async Task Crear(Shared.Dtos.Eleccion.CrearDTO eleccion)
        {
            ArgumentNullException.ThrowIfNull(eleccion);
            if (eleccion.NombreEleccion == null)
                throw new ArgumentNullException(nameof(eleccion.NombreEleccion));

            await Repositorio.Eleccion.Create(eleccion);
        }

        public static async Task Modificar(int id, Shared.Dtos.Eleccion.ModificarDTO eleccionModificar)
        {
            ArgumentNullException.ThrowIfNull(eleccionModificar);
            if (eleccionModificar.NombreEleccion == null)
                throw new ArgumentNullException(nameof(eleccionModificar.NombreEleccion));

            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            await Repositorio.Eleccion.Update(id, eleccionModificar);
        }

        public static async Task<List<Shared.Entities.Eleccion>> ObtenerTodo()
        {
            return await Repositorio.Eleccion.Get();
        }

        public static async Task<Shared.Entities.Eleccion?> obtenerPorId(int id)
        {
            return await Repositorio.Eleccion.Get(id);
        }

        public static async Task<List<Shared.Entities.Eleccion>?> obtenerPorNombre(string nombre)
        {
            return await Repositorio.Eleccion.Get(nombre);
        }

        public static async Task Borrar(int id)
        {
            await Repositorio.Eleccion.Delete(id);
        }

        public static async Task AsignarLista(AsignarListaDTO asignarListaDto)
        {
            ArgumentNullException.ThrowIfNull(asignarListaDto, nameof(asignarListaDto));

            if (asignarListaDto.EleccionId <= 0)
                throw new ArgumentException("EleccionId debe ser mayor a cero.", nameof(asignarListaDto.EleccionId));

            if (asignarListaDto.ListaId <= 0)
                throw new ArgumentException("ListaId debe ser mayor a cero.", nameof(asignarListaDto.ListaId));

            // Llama al método del repositorio para asignar la lista
            await Repositorio.Eleccion.AsignarLista(asignarListaDto);
        }

        public static async Task<List<Shared.Entities.Lista>> ObtenerListasPorEleccion(int eleccionId)
        {
            if (eleccionId <= 0)
                throw new ArgumentException("ID de la elección debe ser mayor a cero");

            return await Repositorio.Eleccion.GetListasByEleccion(eleccionId);
        }

        public static async Task EliminarListaDeEleccion(int eleccionId, int listaId)
        {
            if (eleccionId <= 0 || listaId <= 0)
                throw new ArgumentException("IDs de elección y lista deben ser mayores a cero");

            await Repositorio.Eleccion.RemoveListaFromEleccion(eleccionId, listaId);
        }
        public static async Task<List<string>> ObtenerNombresElecciones()
        {
            try
            {
                var elecciones = await Repositorio.Eleccion.Get();
                if (elecciones == null)
                {
                    return new List<string>(); // Devuelve una lista vacía si no hay elecciones
                }
                return elecciones.Select(e => e.NombreEleccion).ToList();
            }
            catch (Exception ex)
            {
                // Maneja la excepción, por ejemplo, registrándola o lanzando una excepción personalizada
                throw new Exception("Error al obtener los nombres de las elecciones", ex);
            }
        }

        public static async Task AsignarPersonaEleccion(AsignarPersonaEleccionDTO asignarDto)
        {
            ArgumentNullException.ThrowIfNull(asignarDto, nameof(asignarDto));

            if (asignarDto.EleccionId <= 0)
                throw new ArgumentException("EleccionId debe ser mayor a cero.", nameof(asignarDto.EleccionId));

            if (asignarDto.PersonaId <= 0)
                throw new ArgumentException("PersonaId debe ser mayor a cero.", nameof(asignarDto.PersonaId));

            // Llama al método del repositorio para asignar la persona a la elección
            await Repositorio.Eleccion.AsignarPersonaEleccion(asignarDto);
        }

        
    }
}
