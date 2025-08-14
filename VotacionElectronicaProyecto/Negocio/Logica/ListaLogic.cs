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

        public ListaLogic(IListaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<VerDTO>> ObtenerListas()
        {
            var lista = await _repositorio.ObtenerTodos();
            return lista.Select(c => new VerDTO
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

        public async Task CrearLista(CrearDTO dto)
        {
            var existentes = await _repositorio.BuscarPorNombre(dto.NombreLista);
            if (existentes.Any())
                throw new InvalidOperationException("Ya existe una lista con ese nombre.");

            var lista = new Lista
            {
                NombreLista = dto.NombreLista,
                DescripcionLista = dto.DescripcionLista,
            };

            await _repositorio.Crear(lista);
        }

        public async Task ActualizarLista(int id, ModificarDTO dto)
        {
            var listaExistente = await _repositorio.ObtenerPorId(id);
            if (listaExistente == null)
                throw new KeyNotFoundException("La lista que intentas actualizar no existe.");

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
    }
}

