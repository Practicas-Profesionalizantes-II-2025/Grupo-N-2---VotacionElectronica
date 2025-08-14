using Datos.Repositorios.IRepositorios;
using Negocio.Logica.ILogica;
using Shared.Dtos.Candidatos;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica
{
    public class CandidatoLogic : ICandidatoLogic
    {
        private readonly ICandidatoRepository _repositorio;

        public CandidatoLogic(ICandidatoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<VerDTO>> ObtenerCandidatos()
        {
            var lista = await _repositorio.ObtenerTodos();
            return lista.Select(c => new VerDTO
            {
                Id = c.Id,
                NombreCandidato = c.NombreCandidato,
                PuestoCandidato = c.PuestoCandidato,
                IdLista = c.IdLista
            }).ToList();
        }

        public async Task<VerDTO> ObtenerCandidatoPorId(int id)
        {
            var c = await _repositorio.ObtenerPorId(id);
            if (c == null)
                throw new KeyNotFoundException("El candidato no existe.");

            return new VerDTO
            {
                Id = c.Id,
                NombreCandidato = c.NombreCandidato,
                PuestoCandidato = c.PuestoCandidato,
                IdLista = c.IdLista
            };
        }

        public async Task<List<VerDTO>> ObtenerCandidatosPorNombre(string nombre)
        {
            var lista = await _repositorio.BuscarPorNombre(nombre);
            return lista.Select(c => new VerDTO
            {
                Id = c.Id,
                NombreCandidato = c.NombreCandidato,
                PuestoCandidato = c.PuestoCandidato,
                IdLista = c.IdLista
            }).ToList();
        }

        public async Task CrearCandidato(CrearDTO dto)
        {
            var existentes = await _repositorio.BuscarPorNombre(dto.NombreCandidato);
            if (existentes.Any(c => c.IdLista == dto.IdLista && c.PuestoCandidato == dto.PuestoCandidato))
                throw new InvalidOperationException("Ya existe un candidato con ese nombre y puesto en la misma lista.");

            var candidato = new Candidatos
            {
                NombreCandidato = dto.NombreCandidato,
                PuestoCandidato = dto.PuestoCandidato,
                IdLista = dto.IdLista
            };

            await _repositorio.Crear(candidato);
        }

        public async Task ActualizarCandidato(int id, ModificarDTO dto)
        {
            var candidatoExistente = await _repositorio.ObtenerPorId(id);
            if (candidatoExistente == null)
                throw new KeyNotFoundException("El candidato que intentas actualizar no existe.");

            var duplicados = await _repositorio.BuscarPorNombre(dto.NombreCandidato);
            if (duplicados.Any(c => c.Id != id && c.IdLista == candidatoExistente.IdLista && c.PuestoCandidato == dto.PuestoCandidato))
                throw new InvalidOperationException("Ya existe otro candidato con ese nombre y puesto en la misma lista.");

            var candidato = new Candidatos
            {
                Id = id,
                NombreCandidato = dto.NombreCandidato,
                PuestoCandidato = dto.PuestoCandidato
            };

            await _repositorio.Actualizar(candidato);
        }

        public async Task EliminarCandidato(int id)
        {
            var candidatoExistente = await _repositorio.ObtenerPorId(id);
            if (candidatoExistente == null)
                throw new KeyNotFoundException("El candidato que intentas eliminar no existe.");

            await _repositorio.Eliminar(id);
        }
    }

}

