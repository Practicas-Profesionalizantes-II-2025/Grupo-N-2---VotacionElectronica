using Microsoft.AspNetCore.Mvc;
using MVCProyecto.Models.Eleccion;
using MVCProyecto.ViewModels;
using System.Net.Http.Json;

namespace MVCProyecto.Controllers
{
    public class EleccionController : Controller
    {
        private readonly HttpClient _httpClient;

        public EleccionController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // GET: Eleccion/ListaElecciones
        public async Task<IActionResult> ListaEleccion()
        {
            var elecciones = await _httpClient.GetFromJsonAsync<List<VerDTO>>("Eleccion");
            return View(elecciones);
        }

        // GET: Eleccion/DetalleEleccion/5
        public async Task<IActionResult> VerEleccion(int id)
        {
            var eleccion = await _httpClient.GetFromJsonAsync<VerDTO>($"Eleccion/{id}");
            if (eleccion == null) return NotFound();
            return View(eleccion);
        }

        // GET: Eleccion/CrearEleccion
        public IActionResult CrearEleccion() => View();

        // POST: Eleccion/CrearEleccion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEleccion(CrearDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PostAsJsonAsync("Eleccion", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(ListaEleccion));

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
        }

        // GET: Eleccion/EditarEleccion/5
        public async Task<IActionResult> ModificarEleccion(int id)
        {
            var eleccion = await _httpClient.GetFromJsonAsync<VerDTO>($"Eleccion/{id}");
            if (eleccion == null) return NotFound();

            var dto = new ModificarDTO
            {
                NombreEleccion = eleccion.NombreEleccion,
                DescripcionEleccion = eleccion.DescripcionEleccion,
                CantidadListas = eleccion.CantidadListas,
                FechaInicioEleccion = eleccion.FechaInicioEleccion,
                FechaFinEleccion = eleccion.FechaFinEleccion
            };
            return View(dto);
        }

        // POST: Eleccion/EditarEleccion/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificarEleccion(int id, ModificarDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PutAsJsonAsync($"Eleccion/{id}", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(ListaEleccion));

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
        }

        // POST: Eleccion/EliminarEleccion/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarEleccion(int id)
        {
            var response = await _httpClient.DeleteAsync($"Eleccion/{id}");
            return RedirectToAction(nameof(ListaEleccion));
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerListasDisponibles(int eleccionId)
        {
            // 1) Primero intento endpoint específico (si existe en tu API)
            var prefer = await _httpClient.GetAsync($"Lista/Disponibles?eleccionId={eleccionId}");
            if (prefer.IsSuccessStatusCode)
            {
                var listas = await prefer.Content.ReadFromJsonAsync<List<Models.Lista.VerDTO>>();
                return Json(listas);
            }

            // 2) Fallback: traigo todas y resto las ya asignadas
            var todas = await _httpClient.GetFromJsonAsync<List<Models.Lista.VerDTO>>("Lista"); // <-- asegúrate de tener ListaController en la API. Si no, crealo.
            var asignadas = await _httpClient.GetFromJsonAsync<List<Models.Lista.VerDTO>>($"Eleccion/{eleccionId}/Listas");

            todas ??= new List<Models.Lista.VerDTO>();
            asignadas ??= new List<Models.Lista.VerDTO>();

            var disponibles = todas.Where(l => asignadas.All(a => a.Id != l.Id)).ToList();
            return Json(disponibles);
        }

        // ---------- AJAX: listas asignadas a una elección ----------
        [HttpGet]
        public async Task<IActionResult> ObtenerListasAsignadas(int eleccionId)
        {
            var listas = await _httpClient.GetFromJsonAsync<List<Models.Lista.VerDTO>>($"Eleccion/{eleccionId}/Listas");
            return Json(listas ?? new List<Models.Lista.VerDTO>());
        }

        // ---------- POST: asignar lista ----------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AsignarListaEleccion(AsignarListaDTO dto)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ListaEleccion));

            var response = await _httpClient.PostAsJsonAsync("Eleccion/AsignarLista", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(ListaEleccion));

            TempData["Error"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction(nameof(ListaEleccion));
        }

        // ---------- POST: quitar lista ----------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuitarLista(int eleccionId, int listaId)
        {
            var response = await _httpClient.DeleteAsync($"Eleccion/{eleccionId}/Listas/{listaId}");
            return RedirectToAction(nameof(ListaEleccion));
        }


        // GET: Eleccion/AsignarPersona/5
        public IActionResult AsignarPersonaEleccion(int id)
        {
            var dto = new AsignarPersonaEleccionDTO { EleccionId = id };
            return View(dto);
        }

        // POST: Eleccion/AsignarPersona
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AsignarPersonaEleccion(AsignarPersonaEleccionDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PostAsJsonAsync("Eleccion/AsignarPersona", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(VerEleccion), new { id = dto.EleccionId });

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
        }

    }
}
