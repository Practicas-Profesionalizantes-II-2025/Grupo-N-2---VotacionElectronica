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

        // GET: Eleccion/AsignarLista/5
        public async Task<IActionResult> AsignarListaEleccion(int id)
        {
            var dto = new AsignarListaDTO { EleccionId = id, Descripcion = null };
            return View(dto);
        }

        // POST: Eleccion/AsignarLista
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AsignarListaEleccion(AsignarListaDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PostAsJsonAsync("Eleccion/AsignarLista", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(VerEleccion), new { id = dto.EleccionId });

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
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
