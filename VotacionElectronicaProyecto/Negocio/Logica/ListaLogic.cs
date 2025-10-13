using Datos.Repositorios.IRepositorios;
using Negocio.Logica.ILogica;
using Shared.Dtos.Lista;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica
{
    public class ListaLogic : IListaLogic
    {
        private readonly IListaRepository _repositorio;
        private readonly IPersonaRepository _personaRepo;

        public ListaLogic(IListaRepository repositorio, IPersonaRepository personaRepo)
        {
            _repositorio = repositorio;
            _personaRepo = personaRepo;
        }

        public async Task<List<VerDTO>> ObtenerListas(int solicitanteId)
        {
            var solicitante = await _personaRepo.ObtenerPorId(solicitanteId);
            if (solicitante == null)
                throw new InvalidOperationException("Usuario no encontrado");

            var listas = await _repositorio.ObtenerTodos();

            // 🧩 Si no es SuperAdmin, filtra solo las listas creadas por él
            if (solicitante.Rol != "SuperAdmin")
                listas = listas.Where(e => e.CreadorId == solicitante.Id).ToList();

            return listas.Select(c => new VerDTO
            {
                Id = c.Id,
                NombreLista = c.NombreLista,
                DescripcionLista = c.DescripcionLista,
            }).ToList();
        }


        public async Task<VerDTO> ObtenerListasPorId(int id)
        {
            var c = await _repositorio.ObtenerPorId(id);
            if (c == null)
                throw new KeyNotFoundException("La lista no existe.");

            return new VerDTO
            {
                Id = c.Id,
                NombreLista = c.NombreLista,
                DescripcionLista = c.DescripcionLista,
            };
        }

        public async Task<List<VerDTO>> ObtenerListasPorNombre(string nombre)
        {
            var lista = await _repositorio.BuscarPorNombre(nombre);
            return lista.Select(c => new VerDTO
            {
                Id = c.Id,
                NombreLista = c.NombreLista,
                DescripcionLista = c.DescripcionLista,
            }).ToList();
        }

        public async Task CrearLista(CrearDTO dto, int solicitanteId)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Los datos de la lista son obligatorios.");

            ValidacionesNombres.ValidarCampoObligatorio(dto.NombreLista, "Nombre");
            ValidacionesNombres.ValidarCampoObligatorio(dto.DescripcionLista, "Descripcion");


            var existentes = await _repositorio.BuscarPorNombre(dto.NombreLista);
            if (existentes.Any())
                throw new InvalidOperationException("Ya existe una lista con ese nombre.");

            var lista = new Lista
            {
                NombreLista = dto.NombreLista,
                DescripcionLista = dto.DescripcionLista,
                CreadorId = solicitanteId
            };

            await _repositorio.Crear(lista);
        }

        public async Task ActualizarLista(int id, ModificarDTO dto)
        {
            var listaExistente = await _repositorio.ObtenerPorId(id);
            if (listaExistente == null)
                throw new KeyNotFoundException("La lista que intentas actualizar no existe.");
            ValidacionesNombres.ValidarCampoObligatorio(dto.NombreLista, "Nombre");

            var duplicadas = await _repositorio.BuscarPorNombre(dto.NombreLista);
            if (duplicadas.Any(l => l.Id != id))
                throw new InvalidOperationException("Ya existe otra lista con ese nombre.");

            var lista = new Lista
            {
                Id = id,
                NombreLista = dto.NombreLista,
                DescripcionLista = dto.DescripcionLista,
            };

            await _repositorio.Actualizar(lista);
        }

        public async Task EliminarLista(int id)
        {
            var listaExistente = await _repositorio.ObtenerPorId(id);
            if (listaExistente == null)
                throw new KeyNotFoundException("La lista que intentas eliminar no existe.");

            await _repositorio.Eliminar(id);
        }

        public async Task<List<VerDTO>> ObtenerListasNoAsignadas(int eleccionId, int solicitanteId)
        {
            var solicitante = await _personaRepo.ObtenerPorId(solicitanteId);
            if (solicitante == null)
                throw new InvalidOperationException("Usuario no encontrado");

            var listas = solicitante.Rol == "SuperAdmin"
                ? await _repositorio.ObtenerListasNoAsignadas(eleccionId, null)
                : await _repositorio.ObtenerListasNoAsignadas(eleccionId, solicitanteId);

            return listas.Select(l => new VerDTO
            {
                Id = l.Id,
                NombreLista = l.NombreLista,
                DescripcionLista = l.DescripcionLista
            }).ToList();
        }


    }
}

