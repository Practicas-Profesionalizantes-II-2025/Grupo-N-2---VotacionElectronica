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
            var listas = await _httpClient.GetFromJsonAsync<List<VerDTO>>("Lista");
            return View(listas ?? new List<VerDTO>());
        }

        // GET: Lista/CrearLista
        public IActionResult CrearLista() => View();

        // POST: Lista/CrearLista
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearLista(CrearDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PostAsJsonAsync("Lista", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(ListaLista));

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
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
            if (!ModelState.IsValid) return View(dto);

            var response = await _httpClient.PutAsJsonAsync($"Lista/{id}", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(ListaLista));

            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
            return View(dto);
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
            return RedirectToAction(nameof(ListaLista));
        }
    }
}
