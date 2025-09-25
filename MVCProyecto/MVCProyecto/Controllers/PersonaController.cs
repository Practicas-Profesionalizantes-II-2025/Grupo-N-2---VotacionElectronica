using Microsoft.AspNetCore.Mvc;
using MVCProyecto.Models.Persona;
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

        // GET: Persona/ObtenerPersonasDisponibles
        [HttpGet]
        public async Task<IActionResult> ObtenerPersonasDisponibles()
        {
            var personas = await _httpClient.GetFromJsonAsync<List<VerDTO>>("Persona");

            return Json(personas ?? new List<VerDTO>());
        }

        // GET: Persona/ListaPersonas
        public async Task<IActionResult> ListaPersonas()
        {
            var personas = await _httpClient.GetFromJsonAsync<List<VerDTO>>("Persona");
            return View(personas);
        }

        // GET: Persona/BuscarPersona/5
        public async Task<IActionResult> BuscarPersona(int id)
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
        [HttpGet]
        public async Task<IActionResult> EliminarPersona(int id)
        {
            var persona = await _httpClient.GetFromJsonAsync<VerDTO>($"Persona/{id}");
            if (persona == null) return NotFound();
            return PartialView("EliminarPersona", persona);
        }

        // POST: Persona/EliminarConfirmado/5
        [HttpPost, ActionName("EliminarPersona")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var response = await _httpClient.DeleteAsync($"Persona/{id}");
            return RedirectToAction(nameof(ListaPersonas));
        }


        // GET: Persona/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Persona/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            try
            {
                // 🔥 Llamar a la API para autenticar
                var response = await _httpClient.PostAsJsonAsync("Persona/autenticar", dto);

                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                    return View(dto);
                }

                var persona = await response.Content.ReadFromJsonAsync<VerDTO>();

                // 📌 Guardamos usuario en sesión
                HttpContext.Session.SetInt32("UsuarioId", persona.Id);
                HttpContext.Session.SetString("Usuario", persona.NombrePersona);
                HttpContext.Session.SetString("Rol", persona.Rol);
                HttpContext.Session.SetString("Dni", persona.Dni);

                if (persona.PrimerLogin == true)
                {
                    return RedirectToAction("CambiarContrasenia", "Persona");
                }

                return RedirectToAction("Index", "Home");
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError("", "Error de conexión con la API");
                return View(dto);
            }
        }




        [HttpGet]
        public IActionResult CambiarContrasenia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CambiarContrasenia(string nuevaContrasenia)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
                return RedirectToAction("Login");

            // 🔎 Traer los datos actuales de la persona
            var persona = await _httpClient.GetFromJsonAsync<VerDTO>($"Persona/{usuarioId}");
            if (persona == null)
            {
                TempData["Error"] = "Usuario no encontrado";
                return RedirectToAction("Login");
            }

            // 📝 Crear el DTO con todos los campos necesarios
            var dto = new ModificarDTO
            {
                NombrePersona = persona.NombrePersona,
                ApellidoPersona = persona.ApellidoPersona,
                ContraseniaPersona = nuevaContrasenia,
                PrimerLogin = false
            };

            var response = await _httpClient.PutAsJsonAsync($"Persona/{usuarioId}", dto);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Contraseña actualizada correctamente";
                return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = "Error al cambiar la contraseña";
            return View();
        }


    }
}
