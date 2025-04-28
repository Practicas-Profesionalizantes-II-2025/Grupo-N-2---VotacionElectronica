using System.Diagnostics;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Negocio.ClientHttp;
using Negocio.Helper;
using Newtonsoft.Json;
using Shared.Dtos.Eleccion;

namespace Negocio.Repositorio
{
    internal class Eleccion()
    {
        public static async Task<List<Shared.Entities.Eleccion>> Get()
        {
            try
            {
                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(
                        ApiServer.ObtenerUrlEndPoint(
                            ApplicationConfiguration.GetSetting(
                                "ApiServer:EndPoints:Eleccion:ObtenerTodo"
                            )
                        )
                    );

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.Eleccion>>(
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

        public static async Task<Shared.Entities.Eleccion?> Get(int id)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Eleccion:ObtenerPorId"
                );
                path = string.Format(path, id);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Eleccion>(result);

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

        public static async Task<List<Shared.Entities.Eleccion>?> Get(string nombre)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Eleccion:ObtenerPorNombre"
                );
                path = string.Format(path, nombre);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.Eleccion>>(
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

        //public static async Task<Shared.Entities.Eleccion> Create(Shared.Dtos.Eleccion.CrearDTO eleccion)
        //{
        //    try
        //    {
        //        string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Eleccion:Crear");
        //        Debug.WriteLine($"Request URL: {ApiServer.ObtenerUrlEndPoint(path)}");
        //        Debug.WriteLine(JsonConvert.SerializeObject(eleccion, Formatting.Indented));

        //        var stringContent = new StringContent(
        //            JsonConvert.SerializeObject(eleccion),
        //            Encoding.UTF8,
        //            "application/json"
        //        );

        //        var response = await ApiServer
        //            .ObtenerClientHttp()
        //            .PostAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = await response.Content.ReadAsStringAsync();
        //            var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Eleccion>(result);

        //            return returnModel!;
        //        }
        //        else
        //        {
        //            var errorContent = await response.Content.ReadAsStringAsync();
        //            throw new Exception($"Failed to create items returned {response.StatusCode}: {errorContent}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Failed to connect to API server: {ex.Message}");
        //    }
        //}
        public static async Task<Shared.Entities.Eleccion> Create(Shared.Dtos.Eleccion.CrearDTO eleccion)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Eleccion:Crear");
                string requestUrl = ApiServer.ObtenerUrlEndPoint(path);
                Debug.WriteLine($"Request URL: {requestUrl}");
                Debug.WriteLine(JsonConvert.SerializeObject(eleccion, Formatting.Indented));

                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(eleccion),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .PostAsync(requestUrl, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Shared.Entities.Eleccion>(result)!;
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
                    "ApiServer:EndPoints:Eleccion:Borrar"
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

        public static async Task<Shared.Entities.Eleccion> Update(
            int id,
            Shared.Dtos.Eleccion.ModificarDTO eleccion
        )
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Eleccion:Actualizar"
                );
                path = string.Format(path, id);
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(eleccion),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .PutAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Eleccion>(result);

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

        public static async Task AsignarLista(AsignarListaDTO asignarListaDto)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Eleccion:AsignarLista");
                string requestUrl = ApiServer.ObtenerUrlEndPoint(path);
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(asignarListaDto),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer.ObtenerClientHttp().PostAsync(requestUrl, stringContent);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al asignar lista: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Excepción al asignar lista: {ex}");
                throw new Exception($"Error al conectar con el servidor de la API: {ex.Message}", ex);
            }
        }

        public static async Task<List<Shared.Entities.Lista>> GetListasByEleccion(int eleccionId)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Eleccion:ObtenerListasAsignadas");
                path = string.Format(path, eleccionId);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Shared.Entities.Lista>>(result)!;
                }
                else
                {
                    throw new Exception($"Error al obtener listas, código de respuesta: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al conectar con el servidor de la API: {ex.Message}");
            }
        }

        // Método para eliminar una lista de una elección específica
        public static async Task RemoveListaFromEleccion(int eleccionId, int listaId)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Eleccion:EliminarListaDeEleccion");
                path = string.Format(path, eleccionId, listaId);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .DeleteAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al eliminar lista, código de respuesta: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al conectar con el servidor de la API: {ex.Message}");
            }
        }

        public static async Task AsignarPersonaEleccion(AsignarPersonaEleccionDTO asignarDto)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Eleccion:AsignarPersona");
                string requestUrl = ApiServer.ObtenerUrlEndPoint(path);
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(asignarDto),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer.ObtenerClientHttp().PostAsync(requestUrl, stringContent);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al asignar persona a elección: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Excepción al asignar persona a elección: {ex}");
                throw new Exception($"Error al conectar con el servidor de la API: {ex.Message}", ex);
            }
        }
    }

        


}
