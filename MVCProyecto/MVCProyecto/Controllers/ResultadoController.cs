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

        // GET: Resultado/Index
        public async Task<IActionResult> Index()
        {
            var dni = HttpContext.Session.GetString("Dni");
            if (string.IsNullOrEmpty(dni))
            {
                TempData["Error"] = "No se pudo obtener el DNI del usuario en sesión.";
                return RedirectToAction("Login", "Persona");
            }

            // 👇 Usa el mismo endpoint que VotosController.Emitir()
            var elecciones = await _httpClient.GetFromJsonAsync<List<VerDTO>>(
                $"Persona/eleccionesAutorizadas/{dni}");

            return View(elecciones ?? new List<VerDTO>());
        }

        // GET: Resultado/ObtenerResultados?eleccionId=5
        [HttpGet]
        public async Task<IActionResult> ObtenerResultados(int eleccionId)
        {
            if (eleccionId <= 0)
                return BadRequest("ID de elección inválido.");

            var resultados = await _httpClient.GetFromJsonAsync<List<ResultadoDto>>(
                $"api/resultado/{eleccionId}");

            return Json(resultados ?? new List<ResultadoDto>());
        }
    }
}
