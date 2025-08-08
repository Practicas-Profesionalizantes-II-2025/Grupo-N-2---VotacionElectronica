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
    public class PersonaEleccionRepository : IPersonaEleccionRepository
    {
        private readonly DataContext _context;

        public PersonaEleccionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PersonaEleccion> ObtenerPorPersonaYEleccion(int personaId, int eleccionId)
        {
            return await _context.PersonaElecciones
                .FirstOrDefaultAsync(pe => pe.PersonaId == personaId && pe.EleccionId == eleccionId);
        }

        public async Task Actualizar(PersonaEleccion personaEleccion)
        {
            _context.PersonaElecciones.Update(personaEleccion);
            await _context.SaveChangesAsync();
        }
    }
}
