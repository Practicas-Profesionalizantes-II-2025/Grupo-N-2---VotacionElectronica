using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Persona;
using System.Net.Http.Json;

namespace MVCProyecto.Controllers
{
    public class PersonaController : Controller
    {
        private readonly HttpClient _httpClient;

        public PersonaController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // GET: Persona/ListaPersonas
        public async Task<IActionResult> ListaPersonas()
        {
            var personas = await _httpClient.GetFromJsonAsync<List<VerDTO>>("Persona");
            return View(personas);
        }

        // GET: Persona/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var persona = await _httpClient.GetFromJsonAsync<VerDTO>($"Persona/{id}");
            if (persona == null) return NotFound();
            return View(persona);
        }

        // GET: Persona/CrearPersona
        public IActionResult CrearPersona() => View();

        // POST: Persona/CrearPersona
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearPersona(CrearDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PostAsJsonAsync("Persona", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(ListaPersonas));

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
        }

        // GET: Persona/EditarPersona/5
        public async Task<IActionResult> EditarPersona(int id)
        {
            var persona = await _httpClient.GetFromJsonAsync<VerDTO>($"Persona/{id}");
            if (persona == null) return NotFound();

            var dto = new ModificarDTO
            {
                NombrePersona = persona.NombrePersona,
                ApellidoPersona = persona.ApellidoPersona,
                ContraseniaPersona = ""
            };
            return View(dto);
        }

        // POST: Persona/EditarPersona/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarPersona(int id, ModificarDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PutAsJsonAsync($"Persona/{id}", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(ListaPersonas));

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
        }

        // GET: Persona/EliminarPersona/5
        public async Task<IActionResult> EliminarPersona(int id)
        {
            var persona = await _httpClient.GetFromJsonAsync<VerDTO>($"Persona/{id}");
            if (persona == null) return NotFound();
            return View(persona);
        }

        // POST: Persona/EliminarPersona/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var response = await _httpClient.DeleteAsync($"Persona/{id}");
            return RedirectToAction(nameof(ListaPersonas));
        }
    }
}
