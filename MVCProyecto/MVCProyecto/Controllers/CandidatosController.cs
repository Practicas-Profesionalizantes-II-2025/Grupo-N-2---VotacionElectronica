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
            var candidatos = await _httpClient.GetFromJsonAsync<List<VerDTO>>("Candidatos");
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
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PostAsJsonAsync("Candidatos", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(ListaCandidatos));

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
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
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PutAsJsonAsync($"Candidatos/{id}", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(ListaCandidatos));

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
        }

        

        // POST: Candidatos/EliminarCandidato/5
        [HttpPost, ActionName("EliminarCandidato")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var response = await _httpClient.DeleteAsync($"Candidatos/{id}");
            return RedirectToAction(nameof(ListaCandidatos));
        }

    }
}
