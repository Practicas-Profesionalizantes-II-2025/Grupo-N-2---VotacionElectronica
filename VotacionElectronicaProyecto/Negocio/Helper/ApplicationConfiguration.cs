using Microsoft.Extensions.Configuration;

namespace Negocio.Helper
{
    internal class ApplicationConfiguration
    {
        private static IConfigurationRoot _configuration;

        static ApplicationConfiguration()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("negociosettings.json", optional: true, reloadOnChange: true);
                string pal = (Directory.GetCurrentDirectory());
                _configuration = builder.Build();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar la configuración: {ex.Message}");
            }
        }


        public static string GetSetting(string key)
        {
            return (
                (_configuration != null && _configuration[key] != null) ? _configuration[key]! : ""
            );
        }
    }
}
