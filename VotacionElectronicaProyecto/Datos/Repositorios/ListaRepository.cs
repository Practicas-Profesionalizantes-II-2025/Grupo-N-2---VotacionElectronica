using Api.Data;
using Datos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class ListaRepository : IListaRepository
    {
        private readonly DataContext _context;

        public ListaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Lista>> ObtenerTodos()
        {
            return await _context.Lista.ToListAsync();
        }

        public async Task<Lista> ObtenerPorId(int id)
        {
            return await _context.Lista.FindAsync(id);
        }

        public async Task<List<Lista>> BuscarPorNombre(string nombre)
        {
            return await _context.Lista
                .Where(c => c.NombreLista.Contains(nombre))
                .ToListAsync();
        }

        public async Task<Lista> Crear(Lista lista)
        {
            _context.Lista.Add(lista);
            await _context.SaveChangesAsync();
            return lista;
        }

        public async Task Actualizar(Lista lista)
        {
            var existente = await _context.Lista.FindAsync(lista.Id);
            if (existente == null) throw new Exception("Lista no encontrada.");

            existente.NombreLista = lista.NombreLista;
            existente.DescripcionLista = lista.DescripcionLista;

            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var existente = await _context.Lista
                .Include(l => l.Elecciones) // traer las elecciones relacionadas
                .FirstOrDefaultAsync(l => l.Id == id);

            if (existente != null)
            {
                // Guardar las elecciones relacionadas antes de eliminar
                var eleccionesRelacionadas = existente.Elecciones.ToList();

                _context.Lista.Remove(existente);
                await _context.SaveChangesAsync();

                // Recalcular la cantidad de listas de cada elección
                foreach (var eleccion in eleccionesRelacionadas)
                {
                    eleccion.CantidadListas = await _context.EleccionListas
                        .CountAsync(el => el.IdEleccion == eleccion.Id);
                }

                await _context.SaveChangesAsync();
            }
        }


    }
}
