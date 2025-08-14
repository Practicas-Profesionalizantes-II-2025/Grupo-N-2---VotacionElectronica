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
                throw new ArgumentNullException(nameof(votoDto), "Los datos del voto son obligatorios.");

            if (votoDto.PersonaId <= 0)
                throw new ArgumentException("El ID de la persona es inválido.", nameof(votoDto.PersonaId));

            if (votoDto.EleccionId <= 0)
                throw new ArgumentException("El ID de la elección es inválido.", nameof(votoDto.EleccionId));

            if (votoDto.ListaId <= 0)
                throw new ArgumentException("El ID de la lista es inválido.", nameof(votoDto.ListaId));

            var personaEleccion = await _personaEleccionRepo.ObtenerPorPersonaYEleccion(
                votoDto.PersonaId, votoDto.EleccionId);

            if (personaEleccion == null)
                throw new InvalidOperationException("La persona no está registrada para esta elección.");

            if (!personaEleccion.Autorizada)
                throw new InvalidOperationException("La persona no está autorizada para votar o ya ha votado.");

            var votoExistente = await _personaEleccionRepo.ObtenerPorPersonaYEleccion(votoDto.PersonaId, votoDto.EleccionId);
            if (votoExistente != null)
                throw new InvalidOperationException("Ya existe un voto registrado para esta persona en esta elección.");

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
            if (id <= 0)
                throw new ArgumentException("El ID del voto es inválido.", nameof(id));

            await _votoRepo.Eliminar(id);
        }

    }
}
