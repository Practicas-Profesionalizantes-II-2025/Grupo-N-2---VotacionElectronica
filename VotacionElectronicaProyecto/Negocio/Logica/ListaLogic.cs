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
            if (c == null) return null;

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
            var lista = new Lista
            {
                NombreLista = dto.NombreLista,
                DescripcionLista = dto.DescripcionLista,
            };

            await _repositorio.Crear(lista);
        }

        public async Task ActualizarLista(int id, ModificarDTO dto)
        {
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
            await _repositorio.Eliminar(id);
        }
    }
}

