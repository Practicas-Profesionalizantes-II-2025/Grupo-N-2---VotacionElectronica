using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Dtos.Voto;
using Negocio.Logica.ILogica;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotoController : ControllerBase
    {

        private readonly IVotoLogic _logic;

        public VotoController(IVotoLogic logic)
        {
            _logic = logic;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarVoto(CrearDTO dto)
        {
            await _logic.RegistrarVoto(dto);
            return Ok("Voto registrado exitosamente.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarVoto(int id)
        {
            await _logic.EliminarVoto(id);
            return NoContent();
        }

    }
}

