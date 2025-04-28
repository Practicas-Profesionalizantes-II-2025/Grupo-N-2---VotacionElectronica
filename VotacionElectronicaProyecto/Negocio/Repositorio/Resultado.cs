using Microsoft.EntityFrameworkCore;
using Negocio.ClientHttp;
using Negocio.Helper;
using Newtonsoft.Json;
using Shared.Dtos.Resultado;

namespace Negocio.Repositorio
{
    internal class Resultado
    {
        public static async Task<List<ResultadoDto>?> GetResultadosPorEleccion(int eleccionId)
        {
            try
            {
                // Define la ruta para la API que obtendrá los resultados por elección
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Resultado:ObtenerPorEleccion");
                path = string.Format(path, eleccionId);

                // Realiza la llamada a la API
                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    // Lee el contenido de la respuesta
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<ResultadoDto>>(result);

                    // Aquí puedes modificar el DTO para incluir el nombre de la lista
                    // Asumiendo que tienes un método para obtener el nombre de la lista por su ID
                    foreach (var resultado in returnModel)
                    {
                        resultado.NombreLista = await ObtenerNombreListaPorId(resultado.ListaId); // Método a implementar
                    }

                    return returnModel!;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new Exception($"Failed to retrieve item returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception("Failed to connect to API server");
            }
        }

        // Método adicional para obtener el nombre de la lista por su ID
        private static async Task<string> ObtenerNombreListaPorId(int listaId)
        {
            try
            {
                // Define la ruta para obtener la lista por su ID
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Lista:ObtenerPorId");
                path = string.Format(path, listaId);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var lista = JsonConvert.DeserializeObject<Shared.Entities.Lista>(result);
                    return lista?.NombreLista ?? "Nombre no disponible"; // Cambia "Nombre no disponible" según tu lógica
                }
                else
                {
                    return "Nombre no disponible"; // Manejo del error
                }
            }
            catch
            {
                return "Error al obtener nombre"; // Manejo del error
            }
        }





    }
}
