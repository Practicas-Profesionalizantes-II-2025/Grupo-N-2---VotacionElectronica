using Microsoft.AspNetCore.Mvc;
using MVCProyecto.Models.Eleccion;
using MVCProyecto.Models.Resultado;
using System.Net.Http.Json;

namespace MVCProyecto.Controllers
{
    public class ResultadoController : Controller
    {
        private readonly HttpClient _httpClient;

        public ResultadoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // Muestra todas las elecciones disponibles
        public async Task<IActionResult> Index()
        {
            var elecciones = await _httpClient.GetFromJsonAsync<List<VerDTO>>("Eleccion");
            return View(elecciones ?? new List<VerDTO>());
        }

        // Devuelve resultados en JSON (para el modal)
        [HttpGet]
        public async Task<IActionResult> ObtenerResultados(int eleccionId)
        {
            var resultados = await _httpClient.GetFromJsonAsync<List<ResultadoDto>>($"resultado/{eleccionId}");
            return Json(resultados ?? new List<ResultadoDto>());
        }
    }
}
