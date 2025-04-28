namespace Negocio.CasosDeUso
{
    public static class Candidatos
    {
        public static async Task Crear(Shared.Dtos.Candidatos.CrearDTO candidatos)
        {
            ArgumentNullException.ThrowIfNull(candidatos);
            if (candidatos.NombreCandidato == null)
                throw new ArgumentNullException(nameof(candidatos.NombreCandidato));

            await Repositorio.Candidatos.Create(candidatos);
        }

        public static async Task Modificar(int id, Shared.Dtos.Candidatos.ModificarDTO candidatosModificar)
        {
            ArgumentNullException.ThrowIfNull(candidatosModificar);
            if (candidatosModificar.NombreCandidato == null)
                throw new ArgumentNullException(nameof(candidatosModificar.NombreCandidato));
            if (id <= 0)
                throw new ArgumentException("Id debe ser mayor a cero");

            await Repositorio.Candidatos.Update(id, candidatosModificar);
        }

        public static async Task<List<Shared.Entities.Candidatos>> ObtenerTodo()
        {
            return await Repositorio.Candidatos.Get();
        }

        public static async Task<Shared.Entities.Candidatos?> obtenerPorId(int id)
        {
            return await Repositorio.Candidatos.Get(id);
        }

        public static async Task<List<Shared.Entities.Candidatos>?> obtenerPorNombre(string nombre)
        {
            return await Repositorio.Candidatos.Get(nombre);
        }

        public static async Task Borrar(int id)
        {
            await Repositorio.Candidatos.Delete(id);
        }
    }
}
