using System.Security.Cryptography;
using System.Text;
    using Negocio.ClientHttp;
    using Negocio.Helper;
    using Newtonsoft.Json;

    namespace Negocio.Repositorio
    {
        internal class Persona()
        {
            public static async Task<List<Shared.Entities.Persona>> Get()
            {
                try
                {
                    var response = await ApiServer
                        .ObtenerClientHttp()
                        .GetAsync(
                            ApiServer.ObtenerUrlEndPoint(
                                ApplicationConfiguration.GetSetting(
                                    "ApiServer:EndPoints:Persona:ObtenerTodo"
                                )
                            )
                        );

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.Persona>>(
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

            public static async Task<Shared.Entities.Persona?> Get(int id)
            {
                try
                {
                    string path = ApplicationConfiguration.GetSetting(
                        "ApiServer:EndPoints:Persona:ObtenerPorId"
                    );
                    path = string.Format(path, id);

                    var response = await ApiServer
                        .ObtenerClientHttp()
                        .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Persona>(result);

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

            public static async Task<List<Shared.Entities.Persona>?> Get(string nombre)
            {
                try
                {
                    string path = ApplicationConfiguration.GetSetting(
                        "ApiServer:EndPoints:Persona:ObtenerPorNombre"
                    );
                    path = string.Format(path, nombre);

                    var response = await ApiServer
                        .ObtenerClientHttp()
                        .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.Persona>>(
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

            public static async Task<Shared.Entities.Persona> Create(Shared.Dtos.Persona.CrearDTO persona)
            {
                try
                {
                    string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Persona:Crear");
                    var stringContent = new StringContent(
                        JsonConvert.SerializeObject(persona),
                        Encoding.UTF8,
                        "application/json"
                    );

                    var response = await ApiServer
                        .ObtenerClientHttp()
                        .PostAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Persona>(result);

                        return returnModel!;
                    }
                    else
                    {
                        throw new Exception($"Failed to create items returned {response.StatusCode}");
                    }
                }
                catch
                {
                    throw new Exception($"Failed to connect to api server");
                }
            }

            public static async Task Delete(int id)
            {
                try
                {
                    string path = ApplicationConfiguration.GetSetting(
                        "ApiServer:EndPoints:Persona:Borrar"
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

            public static async Task<Shared.Entities.Persona> Update(
                int id,
                Shared.Dtos.Persona.ModificarDTO persona
            )
            {
                try
                {
                    string path = ApplicationConfiguration.GetSetting(
                        "ApiServer:EndPoints:Persona:Actualizar"
                    );
                    path = string.Format(path, id);
                    var stringContent = new StringContent(
                        JsonConvert.SerializeObject(persona),
                        Encoding.UTF8,
                        "application/json"
                    );

                    var response = await ApiServer
                        .ObtenerClientHttp()
                        .PutAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Persona>(result);

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
            
            public static async Task<Shared.Entities.Persona?> GetByPassword(string password)
            {
                try
                {
                    string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Persona:AutenticarPorContraseña");
                    path = string.Format(path, password);

                    var response = await ApiServer.ObtenerClientHttp().GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Persona>(result);

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
                    throw new Exception("Failed to connect to api server");
                }
            }

        public static async Task<Shared.Entities.Persona?> GetByDni(string dni)
        {
            try
            {
                // Obtén el endpoint de la API para buscar una persona por DNI
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Persona:AutenticarPorDni");
                path = string.Format(path, dni);

                // Realiza la solicitud HTTP GET al endpoint correspondiente
                var response = await ApiServer.ObtenerClientHttp().GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    // Lee y deserializa el resultado si la respuesta fue exitosa
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Persona>(result);

                    return returnModel!;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Retorna null si no se encontró ninguna persona con el DNI proporcionado
                    return null;
                }
                else
                {
                    // Lanza una excepción si la respuesta de la API indica un error
                    throw new Exception($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch
            {
                // Lanza una excepción si hubo un problema al conectarse al servidor API
                throw new Exception("Failed to connect to api server");
            }
        }

        public static async Task<List<Shared.Entities.Eleccion>> GetEleccionesAutorizadas(string dni)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Persona:ObtenerEleccionesAutorizadas");
                path = string.Format(path, dni); // Asegúrate de que esta URL esté bien formada.
                string baseUrl = ApplicationConfiguration.GetSetting("ApiServer:BaseUrl");
                string requestUrl = $"{baseUrl}{path}";



                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Shared.Entities.Eleccion>>(result)!;
                }
                else
                {
                    throw new Exception($"Error al obtener elecciones autorizadas, código de respuesta: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al conectar con el servidor de la API: {ex.Message}");
            }
        }




    }
}
