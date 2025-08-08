using Datos.Repositorios.IRepositorios;
using Negocio.Logica.ILogica;
using Shared.Dtos.Voto;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica
{
    public class VotoLogic : IVotoLogic
    {
        private readonly IVotoRepository _votoRepo;
        private readonly IPersonaEleccionRepository _personaEleccionRepo;

        public VotoLogic(IVotoRepository votoRepo, IPersonaEleccionRepository personaEleccionRepo)
        {
            _votoRepo = votoRepo;
            _personaEleccionRepo = personaEleccionRepo;
        }

        public async Task RegistrarVoto(CrearDTO votoDto)
        {
            var personaEleccion = await _personaEleccionRepo.ObtenerPorPersonaYEleccion(
                votoDto.PersonaId, votoDto.EleccionId);

            if (personaEleccion == null || !personaEleccion.Autorizada)
                throw new Exception("La persona no está autorizada o ya ha votado en esta elección.");

            var voto = new Voto
            {
                FechaVoto = DateTime.Now,
                EleccionId = votoDto.EleccionId,
                ListaId = votoDto.ListaId
            };

            await _votoRepo.Crear(voto);

            personaEleccion.Autorizada = false;
            await _personaEleccionRepo.Actualizar(personaEleccion);
        }

        public async Task EliminarVoto(int id)
        {
            await _votoRepo.Eliminar(id);
        }

    }
}
