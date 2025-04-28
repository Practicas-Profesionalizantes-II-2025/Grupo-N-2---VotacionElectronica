using Negocio.Helper;

namespace Negocio.ClientHttp
{
    internal static class ApiServer
    {
        public static HttpClient ObtenerClientHttp()
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.Timeout = TimeSpan.FromSeconds(120);

            return _client;
        }

        internal static string ObtenerUrlEndPoint(string Path)
        {
            string baseUrl = ApplicationConfiguration.GetSetting("ApiServer:BaseURL");

            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new InvalidOperationException("BaseURL is not defined in the configuration.");
            }

            if (!Path.StartsWith("/"))
            {
                Path = "/" + Path;  // Asegúrate de que el path siempre comience con '/'
            }

            return baseUrl + Path;  // Concatenar BaseURL y Path

        }
    }
}
