using Shared.Dtos.Resultado;

namespace Negocio.CasosDeUso
{
    public static class Resultado
    {
        public static async Task<List<ResultadoDto>?> ObtenerResultadosPorEleccion(int eleccionId)
        {
            return await Negocio.Repositorio.Resultado.GetResultadosPorEleccion(eleccionId);
        }

    }
}
