using Microsoft.AspNetCore.Mvc;
using MVCProyecto.Models.Candidatos;

namespace MVCProyecto.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly HttpClient _httpClient;

        public CandidatosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // GET: Candidatos/ListaCandidatos
        public async Task<IActionResult> ListaCandidatos()
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
                return RedirectToAction("Login");

            //Llamada al endpoint filtrado
            var candidatos = await _httpClient.GetFromJsonAsync<List<VerDTO>>($"Candidatos/porUsuario/{usuarioId}");
            return View(candidatos);
        }

        // GET: Candidatos/BuscarPorId/5
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var candidato = await _httpClient.GetFromJsonAsync<VerDTO>($"Candidatos/{id}");
            if (candidato == null) return NotFound();
            return View(candidato);
        }

        // GET: Candidatos/BuscarPorNombre
        [HttpGet]
        public IActionResult BuscarPorNombre() => View();

        // POST: Candidatos/BuscarPorNombre
        [HttpPost]
        public async Task<IActionResult> BuscarPorNombre(string nombre)
        {
            var lista = await _httpClient.GetFromJsonAsync<List<VerDTO>>($"Candidatos/buscarPorNombre/{nombre}");
            return View("ListaCandidatos", lista);
        }

        // GET: Candidatos/CrearCandidato
        public IActionResult CrearCandidato() => View();

        // POST: Candidatos/CrearCandidato
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCandidato(CrearDTO dto)
        {
            if (!ModelState.IsValid)
            {
                // Extraemos los errores de ModelState
                var errores = ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage)
                                .ToList();
                return Json(new { success = false, message = string.Join("<br>", errores) });
            }
            var creadorId = HttpContext.Session.GetInt32("UsuarioId");
            if (creadorId == null)
            {
                return Json(new { success = false, message = "No estás autenticado." });
            }


            var response = await _httpClient.PostAsJsonAsync($"Candidatos/{creadorId}", dto);
            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Candidato creado correctamente." });

            // Mensaje del backend
            var mensajeError = await response.Content.ReadAsStringAsync();
            return Json(new { success = false, message = mensajeError });
        }

        // GET: Candidatos/EditarCandidato/5
        public async Task<IActionResult> EditarCandidato(int id)
        {
            var candidato = await _httpClient.GetFromJsonAsync<VerDTO>($"Candidatos/{id}");
            if (candidato == null) return NotFound();

            var dto = new ModificarDTO
            {
                NombreCandidato = candidato.NombreCandidato,
                PuestoCandidato = candidato.PuestoCandidato
            };
            return View(dto);
        }

        // POST: Candidatos/EditarCandidato/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCandidato(int id, ModificarDTO dto)
        {
            if (!ModelState.IsValid)
            {
                // Extraemos los errores de ModelState
                var errores = ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage)
                                .ToList();
                return Json(new { success = false, message = string.Join("<br>", errores) });
            }
            var response = await _httpClient.PutAsJsonAsync($"Candidatos/{id}", dto);
            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Candidato actualizado correctamente." });

            // Mensaje del backend
            var mensajeError = await response.Content.ReadAsStringAsync();
            return Json(new { success = false, message = mensajeError });
        }

        // GET: Candidatos/EliminarCandidato/5
        [HttpGet]
        public async Task<IActionResult> EliminarCandidato(int id)
        {
            var candidato = await _httpClient.GetFromJsonAsync<VerDTO>($"Candidatos/{id}");
            if (candidato == null) return NotFound();
            return PartialView("EliminarCandidato", candidato);
        }


        // POST: Candidatos/EliminarCandidato/5
        [HttpPost, ActionName("EliminarCandidato")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var response = await _httpClient.DeleteAsync($"Candidatos/{id}");
            return Json(new { success = true, message = "Candidato eliminado correctamente." });
        }

        [HttpGet("Candidatos/PorLista/{listaId}")]
        public async Task<IActionResult> PorLista(int listaId)
        {
            var candidatos = await _httpClient.GetFromJsonAsync<List<VerDTO>>($"Candidatos/PorLista/{listaId}");
            return Json(candidatos ?? new List<VerDTO>());
        }

    }
}
