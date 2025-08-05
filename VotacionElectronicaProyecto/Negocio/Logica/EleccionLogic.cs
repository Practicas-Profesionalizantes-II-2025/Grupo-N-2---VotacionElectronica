using Datos.Repositorios.IRepositorios;
using Negocio.Logica.ILogica;
using Shared.Dtos.Eleccion;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica
{
    public class EleccionLogic : IEleccionLogic
    {
        private readonly IEleccionRepository _repositorio;

        public EleccionLogic(IEleccionRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<VerDTO>> ObtenerTodas()
        {
            var lista = await _repositorio.ObtenerTodas();
            return lista.Select(e => new VerDTO
            {
                Id = e.Id,
                NombreEleccion = e.NombreEleccion,
                DescripcionEleccion = e.DescripcionEleccion,
                CantidadListas = e.CantidadListas,
                FechaInicioEleccion = e.FechaInicioEleccion,
                FechaFinEleccion = e.FechaFinEleccion,
            }).ToList();
        }

        public async Task<VerDTO> ObtenerPorId(int id)
        {
            var e = await _repositorio.ObtenerPorId(id);
            if (e == null) return null;

            return new VerDTO
            {
                Id = e.Id,
                NombreEleccion = e.NombreEleccion,
                DescripcionEleccion = e.DescripcionEleccion,
                CantidadListas = e.CantidadListas,
                FechaInicioEleccion = e.FechaInicioEleccion,
                FechaFinEleccion = e.FechaFinEleccion,
            };
        }

        public async Task<List<VerDTO>> ObtenerPorNombre(string nombre)
        {
            var lista = await _repositorio.ObtenerPorNombre(nombre);
            return lista.Select(e => new VerDTO
            {
                Id = e.Id,
                NombreEleccion = e.NombreEleccion,
                DescripcionEleccion = e.DescripcionEleccion,
                CantidadListas = e.CantidadListas,
                FechaInicioEleccion = e.FechaInicioEleccion,
                FechaFinEleccion = e.FechaFinEleccion,
            }).ToList();
        }

        public async Task<List<VerDTO>> FiltrarPorTexto(string textoBusqueda)
        {
            var lista = await _repositorio.FiltrarPorTexto(textoBusqueda);
            return lista.Select(e => new VerDTO
            {
                Id = e.Id,
                NombreEleccion = e.NombreEleccion,
                DescripcionEleccion = e.DescripcionEleccion,
                CantidadListas = e.CantidadListas,
                FechaInicioEleccion = e.FechaInicioEleccion,
                FechaFinEleccion = e.FechaFinEleccion,
            }).ToList();
        }

        public async Task Crear(CrearDTO dto)
        {
            var eleccion = new Eleccion
            {
                NombreEleccion = dto.NombreEleccion,
                DescripcionEleccion = dto.DescripcionEleccion,
                CantidadListas = dto.CantidadListas,
                FechaInicioEleccion = dto.FechaInicioEleccion,
                FechaFinEleccion = dto.FechaFinEleccion,
                CreatedDate = dto.CreatedDate
            };

            await _repositorio.Crear(eleccion);
        }

        public async Task Actualizar(int id, ModificarDTO dto)
        {
            var eleccion = new Eleccion
            {
                Id = id,
                NombreEleccion = dto.NombreEleccion,
                DescripcionEleccion = dto.DescripcionEleccion,
                CantidadListas = dto.CantidadListas,
                FechaFinEleccion = dto.FechaFinEleccion
            };

            await _repositorio.Actualizar(eleccion);
        }

        public async Task Eliminar(int id)
        {
            await _repositorio.Eliminar(id);
        }

        public async Task AsignarLista(AsignarListaDTO dto)
        {
            await _repositorio.AsignarLista(dto);
        }

        public async Task<List<Lista>> ObtenerListasPorEleccion(int id)
        {
            return await _repositorio.ObtenerListasPorEleccion(id);
        }

        public async Task RemoverListaDeEleccion(int eleccionId, int listaId)
        {
            await _repositorio.RemoverListaDeEleccion(eleccionId, listaId);
        }

        public async Task AsignarPersona(AsignarPersonaEleccionDTO dto)
        {
            await _repositorio.AsignarPersona(dto);
        }

    }
}
