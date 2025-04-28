using System.Diagnostics;
using System.Text;
using Negocio.ClientHttp;
using Negocio.Helper;
using Newtonsoft.Json;

namespace Negocio.Repositorio
{
    internal class Candidatos()
    {
        public static async Task<List<Shared.Entities.Candidatos>> Get()
        {
            try
            {
                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(
                        ApiServer.ObtenerUrlEndPoint(
                            ApplicationConfiguration.GetSetting(
                                "ApiServer:EndPoints:Candidatos:ObtenerTodo"
                            )
                        )
                    );

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.Candidatos>>(
                        result
                    );

                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<Shared.Entities.Candidatos?> Get(int id)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Candidatos:ObtenerPorId"
                );
                path = string.Format(path, id);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Candidatos>(result);

                    return returnModel!;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new Exception($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<List<Shared.Entities.Candidatos>?> Get(string nombre)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Candidatos:ObtenerPorNombre"
                );
                path = string.Format(path, nombre);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.Candidatos>>(
                        result
                    );

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
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<Shared.Entities.Candidatos> Create(Shared.Dtos.Candidatos.CrearDTO candidatos)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Candidatos:Crear");
                string requestUrl = ApiServer.ObtenerUrlEndPoint(path);
                Debug.WriteLine($"Request URL: {requestUrl}");
                Debug.WriteLine(JsonConvert.SerializeObject(candidatos, Formatting.Indented));

                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(candidatos),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .PostAsync(requestUrl, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Shared.Entities.Candidatos>(result)!;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al crear elementos: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                // Registra los detalles de la excepción original para una mejor depuración
                Debug.WriteLine($"Excepción Original: {ex}");
                throw new Exception($"Error al conectar con el servidor de la API: {ex.Message}", ex);
            }
        }

        public static async Task Delete(int id)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Candidatos:Borrar"
                );
                path = string.Format(path, id);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .DeleteAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"Failed to delete items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<Shared.Entities.Candidatos> Update(
            int id,
            Shared.Dtos.Candidatos.ModificarDTO candidatos
        )
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Candidatos:Actualizar"
                );
                path = string.Format(path, id);
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(candidatos),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .PutAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Candidatos>(result);

                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to update items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }
    }
}
