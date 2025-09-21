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
            if (votoDto == null)
                throw new ArgumentNullException(nameof(votoDto));

            if (votoDto.PersonaId <= 0)
                throw new ArgumentException("ID de persona inválido.", nameof(votoDto.PersonaId));

            if (votoDto.EleccionId <= 0)
                throw new ArgumentException("ID de elección inválido.", nameof(votoDto.EleccionId));

            if (votoDto.ListaId < 0)
                throw new ArgumentException("ID de lista inválido.", nameof(votoDto.ListaId));

            var personaEleccion = await _personaEleccionRepo.ObtenerPorPersonaYEleccion(
                votoDto.PersonaId, votoDto.EleccionId);

            if (personaEleccion == null)
                throw new InvalidOperationException("La persona no está registrada para esta elección.");

            if (!personaEleccion.Autorizada)
                throw new InvalidOperationException("La persona no está autorizada para votar o ya ha votado.");

            // Registro el voto (anónimo)
            var voto = new Voto
            {
                FechaVoto = DateTime.Now,
                EleccionId = votoDto.EleccionId,
                ListaId = votoDto.ListaId
            };

            await _votoRepo.Crear(voto);

            // Desautorizo para que no pueda volver a votar
            personaEleccion.Autorizada = false;
            await _personaEleccionRepo.Actualizar(personaEleccion);
        }


        public async Task EliminarVoto(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del voto es inválido.", nameof(id));

            await _votoRepo.Eliminar(id);
        }

    }
}
