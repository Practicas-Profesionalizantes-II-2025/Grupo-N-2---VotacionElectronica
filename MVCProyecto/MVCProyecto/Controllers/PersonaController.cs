using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Persona;
using System.Net.Http;
using System.Net.Http.Json;

namespace TuProyecto.Controllers
{
    public class PersonaController : Controller
    {
        private readonly HttpClient _httpClient;

        // Inyectamos HttpClient (recomendado usar IHttpClientFactory en Program.cs)
        public PersonaController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
            // "ApiClient" lo configuras en Program.cs con la BaseAddress
        }

        // GET: Persona/CrearPersona
        [HttpGet]
        public IActionResult CrearPersona()
        {
            return View();
        }

        // POST: Persona/CrearPersona
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearPersona(CrearDTO crearDto)
        {
            if (!ModelState.IsValid)
            {
                // Si hay errores de validación, mostramos el formulario de nuevo
                return View(crearDto);
            }

            try
            {
                // Enviamos el DTO a la API
                var response = await _httpClient.PostAsJsonAsync("Persona", crearDto);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Exito"] = "Persona creada correctamente.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Capturamos el mensaje de error de la API si existe
                    var error = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error al crear persona: {error}");
                    return View(crearDto);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
                return View(crearDto);
            }
        }
    }
}

