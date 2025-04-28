using Shared.Dtos.Voto;
using Shared.Dtos.Lista;


namespace Negocio.CasosDeUso
{
    public static class Lista
    {
        public static async Task Crear(Shared.Dtos.Lista.CrearDTO lista)
        {
            ArgumentNullException.ThrowIfNull(lista);
            if (lista.NombreLista == null)
                throw new ArgumentNullException(nameof(lista.NombreLista));

            await Repositorio.Lista.Create(lista);
        }

        public static async Task Modificar(int id, Shared.Dtos.Lista.ModificarDTO listaModificar)
        {
            ArgumentNullException.ThrowIfNull(listaModificar);
            if (listaModificar.NombreLista == null)
                throw new ArgumentNullException(nameof(listaModificar.NombreLista));

            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            await Repositorio.Lista.Update(id, listaModificar);
        }

        public static async Task<List<Shared.Entities.Lista>> ObtenerTodo()
        {
            return await Repositorio.Lista.Get();
        }
        public static async Task<Shared.Entities.Lista?> obtenerPorId(int id)
        {
            return await Repositorio.Lista.Get(id);
        }

        public static async Task<List<Shared.Entities.Lista>?> obtenerPorNombre(string nombre)
        {
            return await Repositorio.Lista.Get(nombre);
        }

        public static async Task Borrar(int id)
        {
            await Repositorio.Lista.Delete(id);
        }
    }
}
