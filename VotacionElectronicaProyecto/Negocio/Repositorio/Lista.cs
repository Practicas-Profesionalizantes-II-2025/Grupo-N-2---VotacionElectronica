using System.Diagnostics;
using System.Text;
using Negocio.ClientHttp;
using Negocio.Helper;
using Newtonsoft.Json;
using Shared.Dtos.Lista;

namespace Negocio.Repositorio
{
    internal class Lista()
    {
        public static async Task<List<Shared.Entities.Lista>> Get()
        {
            try
            {
                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(
                        ApiServer.ObtenerUrlEndPoint(
                            ApplicationConfiguration.GetSetting(
                                "ApiServer:EndPoints:Lista:ObtenerTodo"
                            )
                        )
                    );

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.Lista>>(
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

        public static async Task<Shared.Entities.Lista?> Get(int id)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Lista:ObtenerPorId"
                );
                path = string.Format(path, id);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Lista>(result);

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

        public static async Task<List<Shared.Entities.Lista>?> Get(string nombre)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Lista:ObtenerPorNombre"
                );
                path = string.Format(path, nombre);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.Lista>>(
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

        //public static async Task<Shared.Entities.Lista> Create(Shared.Dtos.Lista.CrearDTO lista)
        //{
        //    try
        //    {
        //        string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Lista:Crear");
        //        var stringContent = new StringContent(
        //            JsonConvert.SerializeObject(lista),
        //            Encoding.UTF8,
        //            "application/json"
        //        );

        //        var response = await ApiServer
        //            .ObtenerClientHttp()
        //            .PostAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = await response.Content.ReadAsStringAsync();
        //            var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Lista>(result);

        //            return returnModel!;
        //        }
        //        else
        //        {
        //            throw new Exception($"Failed to create items returned {response.StatusCode}");
        //        }
        //    }
        //    catch
        //    {
        //        throw new Exception($"Failed to connect to api server");
        //    }
        //}
        public static async Task<Shared.Entities.Lista> Create(Shared.Dtos.Lista.CrearDTO lista)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Lista:Crear");
                string requestUrl = ApiServer.ObtenerUrlEndPoint(path);
                Debug.WriteLine($"Request URL: {requestUrl}");
                Debug.WriteLine(JsonConvert.SerializeObject(lista, Formatting.Indented));

                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(lista),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .PostAsync(requestUrl, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Shared.Entities.Lista>(result)!;
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
                        "ApiServer:EndPoints:Lista:Borrar"
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

            public static async Task<Shared.Entities.Lista> Update(
                int id,
                Shared.Dtos.Lista.ModificarDTO lista
            )
            {
                try
                {
                    string path = ApplicationConfiguration.GetSetting(
                        "ApiServer:EndPoints:Lista:Actualizar"
                    );
                    path = string.Format(path, id);
                    var stringContent = new StringContent(
                        JsonConvert.SerializeObject(lista),
                        Encoding.UTF8,
                        "application/json"
                    );

                    var response = await ApiServer
                        .ObtenerClientHttp()
                        .PutAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Lista>(result);

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
