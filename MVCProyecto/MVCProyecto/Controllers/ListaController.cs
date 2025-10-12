using Microsoft.AspNetCore.Mvc;
using MVCProyecto.Models.Lista;
namespace MVCProyecto.Controllers
{
    public class ListaController : Controller
    {
        private readonly HttpClient _httpClient;

        public ListaController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // GET: Lista
        public async Task<IActionResult> ListaLista()
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
                return RedirectToAction("Login");

            // 👇 Ahora encaja con la ruta de la API
            var listas = await _httpClient.GetFromJsonAsync<List<VerDTO>>($"Lista/porUsuario/{usuarioId}");
            var filtradas = listas?.Where(l => !l.NombreLista.Equals("Voto en blanco", StringComparison.OrdinalIgnoreCase)).ToList();

            return View(filtradas ?? new List<VerDTO>());
        }

        [HttpGet]
        public async Task<IActionResult> PorEleccion(int eleccionId)
        {
            // Llamo a la API que devuelve listas de una elección
            var listas = await _httpClient.GetFromJsonAsync<List<VerDTO>>($"Lista/PorEleccion/{eleccionId}");

            ViewBag.EleccionId = eleccionId;
            return View("ListasPorEleccion", listas ?? new List<VerDTO>());
        }

        // GET: Lista/CrearLista
        public IActionResult CrearLista() => View();

        // POST: Lista/CrearLista
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearLista(CrearDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

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

            // 👇 Ruta corregida según la API
            var response = await _httpClient.PostAsJsonAsync($"Lista/{creadorId}", dto);
            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Lista creada correctamente." });

            // Mensaje del backend
            var mensajeError = await response.Content.ReadAsStringAsync();
            return Json(new { success = false, message = mensajeError });

        }


        // GET: Lista/EditarLista/5
        public async Task<IActionResult> EditarLista(int id)
        {
            var lista = await _httpClient.GetFromJsonAsync<VerDTO>($"Lista/{id}");
            if (lista == null) return NotFound();

            var dto = new ModificarDTO
            {
                NombreLista = lista.NombreLista,
                DescripcionLista = lista.DescripcionLista
            };
            return View(dto);
        }

        // POST: Lista/EditarLista/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarLista(int id, ModificarDTO dto)
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

            var response = await _httpClient.PutAsJsonAsync($"Lista/{id}", dto);
            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Lista actualizada correctamente." });

            // Mensaje del backend
            var mensajeError = await response.Content.ReadAsStringAsync();
            return Json(new { success = false, message = mensajeError });
        }

        // GET: Lista/EliminarLista/5
        [HttpGet]
        public async Task<IActionResult> EliminarLista(int id)
        {
            var lista = await _httpClient.GetFromJsonAsync<VerDTO>($"Lista/{id}");
            if (lista == null) return NotFound();
            return PartialView("EliminarLista", lista);
        }


        // POST: Lista/EliminarLista/5
        [HttpPost, ActionName("EliminarLista")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var response = await _httpClient.DeleteAsync($"Lista/{id}");
            return Json(new { success = true, message = "Lista eliminada correctamente." });
        }
    }
}
