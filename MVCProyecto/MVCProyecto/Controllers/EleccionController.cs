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


            var response = await _httpClient.PostAsJsonAsync($"Eleccion/{creadorId}", dto);
            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Eleccion creada correctamente." });

            // Mensaje del backend
            var mensajeError = await response.Content.ReadAsStringAsync();
            return Json(new { success = false, message = mensajeError });
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
            if (!ModelState.IsValid)
            {
                // Extraemos los errores de ModelState
                var errores = ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage)
                                .ToList();
                return Json(new { success = false, message = string.Join("<br>", errores) });
            }
            var response = await _httpClient.PutAsJsonAsync($"Eleccion/{id}", dto);
            if (response.IsSuccessStatusCode)
                return Json(new { success = true, message = "Eleccion actualizada correctamente." });

            // Mensaje del backend
            var mensajeError = await response.Content.ReadAsStringAsync();
            return Json(new { success = false, message = mensajeError });

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
            return Json(new { success = true, message = "Eleccion eliminada correctamente." });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerListasDisponibles(int eleccionId)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
                return Json(new { error = "Usuario no autenticado" });

            var response = await _httpClient.GetAsync($"Lista/noAsignadas/{eleccionId}/{usuarioId}");
            if (!response.IsSuccessStatusCode)
                return Json(new List<MVCProyecto.Models.Lista.VerDTO>());

            var listas = await response.Content.ReadFromJsonAsync<List<MVCProyecto.Models.Lista.VerDTO>>();
            var listasFiltradas = listas?
                .Where(l => !string.Equals(l.NombreLista, "Voto en Blanco", StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Json(listasFiltradas ?? new List<MVCProyecto.Models.Lista.VerDTO>());
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
            {
                TempData["Error"] = "No se seleccionaron listas.";
                return RedirectToAction(nameof(ListaEleccion)); 
            }

            var response = await _httpClient.PostAsJsonAsync("Eleccion/AsignarLista", dto);
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Lista asignada correctamente.";
                return RedirectToAction(nameof(ListaEleccion)); 
            }

            var error = await response.Content.ReadAsStringAsync();
            TempData["Error"] = error;
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
            if (dto.PersonaIds == null || !dto.PersonaIds.Any())
            {
                TempData["Error"] = "Debe seleccionar al menos una persona.";
                return RedirectToAction(nameof(ListaEleccion));
            }

            foreach (var personaId in dto.PersonaIds)
            {
                var asignacion = new
                {
                    EleccionId = dto.EleccionId,
                    PersonaId = personaId,
                    Autorizada = dto.Autorizada
                };

                var response = await _httpClient.PostAsJsonAsync("Eleccion/AsignarPersona", asignacion);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    TempData["Error"] = $"Error al asignar persona ID {personaId}: {error}";
                    return RedirectToAction(nameof(ListaEleccion));
                }
            }

            TempData["Success"] = "Personas asignadas correctamente ✅";
            return RedirectToAction(nameof(ListaEleccion));
        }



        [HttpGet]
        public async Task<IActionResult> ObtenerPersonasDisponibles(int eleccionId)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
                return Json(new { error = "Usuario no autenticado" });

            var response = await _httpClient.GetAsync($"Persona/noAsignadas/{eleccionId}/{usuarioId}");
            if (!response.IsSuccessStatusCode)
                return Json(new List<MVCProyecto.Models.Persona.VerDTO>());

            var personas = await response.Content.ReadFromJsonAsync<List<MVCProyecto.Models.Persona.VerDTO>>();
            return Json(personas ?? new List<MVCProyecto.Models.Persona.VerDTO>());
        }




    }
}
