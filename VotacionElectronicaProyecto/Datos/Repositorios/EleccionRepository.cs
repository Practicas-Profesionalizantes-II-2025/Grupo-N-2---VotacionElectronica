using Api.Data;
using Datos.Repositorios.IRepositorios;
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
    public class EleccionRepository : IEleccionRepository
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

            // Actualizar CantidadListas desde la DB
            var eleccion = await _context.Eleccion.FindAsync(dto.EleccionId);
            eleccion.CantidadListas = await _context.EleccionListas.CountAsync(el => el.IdEleccion == dto.EleccionId);
            await _context.SaveChangesAsync();
        }



        public async Task<List<Lista>> ObtenerListasPorEleccion(int eleccionId)
        {
            var eleccion = await _context.Eleccion
                .Include(e => e.Listas)
                .FirstOrDefaultAsync(e => e.Id == eleccionId);
            eleccion.CantidadListas = eleccion.Listas.Count;

            return eleccion?.Listas?.ToList() ?? new List<Lista>();
        }

        public async Task RemoverListaDeEleccion(int eleccionId, int listaId)
        {
            var eleccionLista = await _context.EleccionListas
                .FirstOrDefaultAsync(el => el.IdEleccion == eleccionId && el.IdLista == listaId);

            if (eleccionLista != null)
            {
                _context.EleccionListas.Remove(eleccionLista);
                await _context.SaveChangesAsync();

                var eleccion = await _context.Eleccion.FindAsync(eleccionId);
                eleccion.CantidadListas = await _context.EleccionListas.CountAsync(el => el.IdEleccion == eleccionId);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AsignarPersona(AsignarPersonaEleccionDTO dto)
        {
            // Validar que existan
            var personaExiste = await _context.Persona.AnyAsync(p => p.Id == dto.PersonaId);
            var eleccionExiste = await _context.Eleccion.AnyAsync(e => e.Id == dto.EleccionId);

            if (!personaExiste || !eleccionExiste)
                throw new Exception("La persona o la elección no existen.");

            // Evitar duplicados
            var existe = await _context.PersonaElecciones
                .AnyAsync(pe => pe.PersonaId == dto.PersonaId && pe.EleccionId == dto.EleccionId);

            if (existe)
                throw new Exception("La persona ya está asignada a esta elección.");

            // Crear nueva relación
            var personaEleccion = new PersonaEleccion
            {
                PersonaId = dto.PersonaId,
                EleccionId = dto.EleccionId,
                Autorizada = dto.Autorizada // respeta lo que venga del DTO
            };

            _context.PersonaElecciones.Add(personaEleccion);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Shared.Dtos.Persona.VerDTO>> ObtenerPersonasPorEleccion(int eleccionId)
        {
            return await _context.PersonaElecciones
                                 .Where(pe => pe.EleccionId == eleccionId)
                                 .Select(pe => new Shared.Dtos.Persona.VerDTO
                                 {
                                     Id = pe.Persona.Id,
                                     NombrePersona = pe.Persona.NombrePersona,
                                     ApellidoPersona = pe.Persona.ApellidoPersona,
                                     Dni = pe.Persona.NroIdentificacionPersona,
                                 })
                                 .ToListAsync();
        }

    }
}
