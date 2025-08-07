using Datos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Data;

namespace Datos.Repositorios
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly DataContext _context;

        public CandidatoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Candidatos>> ObtenerTodos()
        {
            return await _context.Candidatos.ToListAsync();
        }

        public async Task<Candidatos> ObtenerPorId(int id)
        {
            return await _context.Candidatos.FindAsync(id);
        }

        public async Task<List<Candidatos>> BuscarPorNombre(string nombre)
        {
            return await _context.Candidatos
                .Where(c => c.NombreCandidato.Contains(nombre))
                .ToListAsync();
        }

        public async Task<Candidatos> Crear(Candidatos candidato)
        {
            _context.Candidatos.Add(candidato);
            await _context.SaveChangesAsync();
            return candidato;
        }

        public async Task Actualizar(Candidatos candidato)
        {
            var existente = await _context.Candidatos.FindAsync(candidato.Id);
            if (existente == null) throw new Exception("Candidato no encontrado.");

            existente.NombreCandidato = candidato.NombreCandidato;
            existente.PuestoCandidato = candidato.PuestoCandidato;

            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var existente = await _context.Candidatos.FindAsync(id);
            if (existente != null)
            {
                _context.Candidatos.Remove(existente);
                await _context.SaveChangesAsync();
            }
        }

    }
}
