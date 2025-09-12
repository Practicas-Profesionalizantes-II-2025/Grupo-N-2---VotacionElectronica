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

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("Lista", dto);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(await response.Content.ReadAsStringAsync());
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int id, [FromBody] ModificarDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"Lista/{id}", dto);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(await response.Content.ReadAsStringAsync());
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"Lista/{id}");
            return response.IsSuccessStatusCode ? Ok() : BadRequest();
        }
    }
}
