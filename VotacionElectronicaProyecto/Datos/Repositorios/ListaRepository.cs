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
            var existente = await _context.Lista.FindAsync(id);
            if (existente != null)
            {
                _context.Lista.Remove(existente);
                await _context.SaveChangesAsync();
            }
        }

    }
}
