using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace MVCProyecto.Controllers
{
    public class VotosController : Controller
    {
        private readonly HttpClient _httpClient;

        public VotosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // GET: Votos/Emitir
        public async Task<IActionResult> Emitir()
        {
            var dni = HttpContext.Session.GetString("Dni");
            if (string.IsNullOrEmpty(dni))
            {
                TempData["Error"] = "No se pudo obtener el DNI del usuario en sesión.";
                return RedirectToAction("Login", "Persona");
            }

            // Llamo al endpoint de PersonaController
            var elecciones = await _httpClient.GetFromJsonAsync<List<MVCProyecto.Models.Eleccion.VerDTO>>(
                $"Persona/eleccionesAutorizadas/{dni}");

            return View(elecciones ?? new List<MVCProyecto.Models.Eleccion.VerDTO>());
        }


        // GET: Votos/Listas/5
        public async Task<IActionResult> Listas(int eleccionId)
        {
            var listas = await _httpClient.GetFromJsonAsync<List<MVCProyecto.Models.Lista.VerDTO>>($"Eleccion/{eleccionId}/Listas");
            ViewBag.EleccionId = eleccionId;
            return View(listas ?? new List<MVCProyecto.Models.Lista.VerDTO>());
        }

        // POST: Votos/Registrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(int eleccionId, int listaId)
        {
            var personaId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;
            // 0 = voto en blanco
            var dto = new Models.Voto.CrearDTO
            {
                EleccionId = eleccionId,
                ListaId = listaId, // puede ser >0 (lista real) o 0 (blanco)
                PersonaId = personaId
            };

            var response = await _httpClient.PostAsJsonAsync("Voto", dto);

            if (response.IsSuccessStatusCode)
            {
                // Vamos a la pantalla de confirmación
                return RedirectToAction("Listo");
            }

            TempData["Error"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("Emitir");
        }

        // GET: Votos/Listo
        public IActionResult Listo()
        {
            return View();
        }
    }
}
