using Api.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Eleccion;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class EleccionRepository
    {
        private readonly DataContext _context;

        public EleccionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Eleccion>> ObtenerTodas()
        {
            return await _context.Eleccion.ToListAsync();
        }

        public async Task<Eleccion> ObtenerPorId(int id)
        {
            return await _context.Eleccion.FindAsync(id);
        }

        public async Task<List<Eleccion>> ObtenerPorNombre(string nombre)
        {
            return await _context.Eleccion
                .Where(e => e.NombreEleccion.Contains(nombre))
                .ToListAsync();
        }

        public async Task<List<Eleccion>> FiltrarPorTexto(string texto)
        {
            return await _context.Eleccion
                .Where(e => e.NombreEleccion != null && e.NombreEleccion.ToLower().StartsWith(texto.ToLower()))
                .ToListAsync();
        }

        public async Task<Eleccion> Crear(Eleccion eleccion)
        {
            _context.Eleccion.Add(eleccion);
            await _context.SaveChangesAsync();
            return eleccion;
        }

        public async Task Actualizar(Eleccion eleccion)
        {
            var existente = await _context.Eleccion.FindAsync(eleccion.Id);
            if (existente == null)
            {
                throw new Exception("Elección no encontrada.");
            }

            existente.NombreEleccion = eleccion.NombreEleccion;
            existente.DescripcionEleccion = eleccion.DescripcionEleccion;
            existente.CantidadListas = eleccion.CantidadListas;
            existente.FechaFinEleccion = eleccion.FechaFinEleccion;

            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var eleccion = await _context.Eleccion.FindAsync(id);
            if (eleccion != null)
            {
                _context.Eleccion.Remove(eleccion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AsignarLista(AsignarListaDTO dto)
        {
            var eleccionLista = new EleccionLista
            {
                IdEleccion = dto.EleccionId,
                IdLista = dto.ListaId,
                DescripcionEleccionLista = dto.Descripcion
            };

            _context.EleccionListas.Add(eleccionLista);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Lista>> ObtenerListasPorEleccion(int eleccionId)
        {
            var eleccion = await _context.Eleccion
                .Include(e => e.Listas)
                .FirstOrDefaultAsync(e => e.Id == eleccionId);

            return eleccion?.Listas?.ToList() ?? new List<Lista>();
        }

        public async Task RemoverListaDeEleccion(int eleccionId, int listaId)
        {
            var eleccion = await _context.Eleccion
                .Include(e => e.Listas)
                .FirstOrDefaultAsync(e => e.Id == eleccionId);

            if (eleccion != null)
            {
                var lista = eleccion.Listas.FirstOrDefault(l => l.Id == listaId);
                if (lista != null)
                {
                    eleccion.Listas.Remove(lista);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task AsignarPersona(AsignarPersonaEleccionDTO dto)
        {
            var personaEleccion = new PersonaEleccion
            {
                PersonaId = dto.PersonaId,
                EleccionId = dto.EleccionId,
                Autorizada = true
            };

            _context.PersonaElecciones.Add(personaEleccion);
            await _context.SaveChangesAsync();
        }

    }
}
