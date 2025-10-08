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
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
                return RedirectToAction("Login");

            // 👇 Llamada al endpoint filtrado
            var elecciones = await _httpClient.GetFromJsonAsync<List<VerDTO>>($"Eleccion/porUsuario/{usuarioId}");
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

            var creadorId = HttpContext.Session.GetInt32("UsuarioId");
            if (creadorId == null)
            {
                ModelState.AddModelError("", "No estás autenticado.");
                return View(dto);
            }

            var response = await _httpClient.PostAsJsonAsync($"Eleccion/{creadorId}", dto);
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

        [HttpGet]
        public async Task<IActionResult> EliminarEleccion(int id)
        {
            var eleccion = await _httpClient.GetFromJsonAsync<VerDTO>($"Eleccion/{id}");
            if (eleccion == null) return NotFound();

            return PartialView("EliminarEleccion", eleccion);
        }

        // POST: Eleccion/EliminarEleccion/5
        [HttpPost, ActionName("EliminarEleccion")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarEleccionConfirmada(int id)
        {
            var response = await _httpClient.DeleteAsync($"Eleccion/{id}");
            return RedirectToAction(nameof(ListaEleccion));
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerListasDisponibles(int eleccionId)
        {
            var prefer = await _httpClient.GetAsync($"Lista/Disponibles?eleccionId={eleccionId}");
            if (prefer.IsSuccessStatusCode)
            {
                var listas = await prefer.Content.ReadFromJsonAsync<List<Models.Lista.VerDTO>>();
                // ⚠️ Filtrar “Voto en blanco”
                var filtradas = listas?.Where(l => !l.NombreLista.Equals("Voto en blanco", StringComparison.OrdinalIgnoreCase)).ToList();
                return Json(filtradas);
            }

            // Fallback
            var todas = await _httpClient.GetFromJsonAsync<List<Models.Lista.VerDTO>>("Lista");
            var asignadas = await _httpClient.GetFromJsonAsync<List<Models.Lista.VerDTO>>($"Eleccion/{eleccionId}/Listas");

            todas ??= new List<Models.Lista.VerDTO>();
            asignadas ??= new List<Models.Lista.VerDTO>();

            var disponibles = todas
                .Where(l => asignadas.All(a => a.Id != l.Id)
                            && !l.NombreLista.Equals("Voto en blanco", StringComparison.OrdinalIgnoreCase))
                .ToList();

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


        

        // POST: Eleccion/AsignarPersona
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AsignarPersonaEleccion(AsignarPersonaEleccionDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PostAsJsonAsync("Eleccion/AsignarPersona", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(ListaEleccion));

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPersonasDisponibles(int eleccionId)
        {
            // 1) Todas las personas
            var todas = await _httpClient.GetFromJsonAsync<List<MVCProyecto.Models.Persona.VerDTO>>("Persona");

            // 2) Personas ya asignadas a esta elección
            var asignadas = await _httpClient.GetFromJsonAsync<List<MVCProyecto.Models.Persona.VerDTO>>($"Eleccion/{eleccionId}/Personas");

            todas ??= new List<MVCProyecto.Models.Persona.VerDTO>();
            asignadas ??= new List<MVCProyecto.Models.Persona.VerDTO>();

            // 3) Filtrar: solo las que no están asignadas y cuyo rol sea "Votante"
            var disponibles = todas
                .Where(p => asignadas.All(a => a.Id != p.Id) && p.Rol.Equals("Votante", StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Json(disponibles);
        }




    }
}
