using Negocio.ClientHttp;
using Negocio.Helper;
using Newtonsoft.Json;
using System.Text;
using Shared.Dtos.Voto;
using System.Diagnostics;

namespace Negocio.Repositorio
{
    internal class Voto
    {
        public static async Task RegistrarVoto(CrearDTO votoDto)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Voto:Registrar");
                string requestUrl = ApiServer.ObtenerUrlEndPoint(path);
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(votoDto),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer.ObtenerClientHttp().PostAsync(requestUrl, stringContent);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al registrar el voto: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Excepción al registrar el voto: {ex}");
                throw new Exception($"Error al conectar con el servidor de la API: {ex.Message}", ex);
            }
        }
    }
}
