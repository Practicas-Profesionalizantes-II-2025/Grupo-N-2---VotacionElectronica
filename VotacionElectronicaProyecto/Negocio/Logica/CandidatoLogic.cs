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
            if (c == null) return null;

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
            await _repositorio.Eliminar(id);
        }
    }

}

