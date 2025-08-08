using Api.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class PersonaRepository
    {
        private readonly DataContext _context;

        public PersonaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Persona>> ObtenerTodas()
        {
            return await _context.Persona.ToListAsync();
        }

        public async Task<Persona> ObtenerPorId(int id)
        {
            return await _context.Persona.FindAsync(id);
        }

        public async Task<List<Persona>> ObtenerPorNombre(string nombre)
        {
            return await _context.Persona
                .Where(p => p.NombrePersona.Contains(nombre))
                .ToListAsync();
        }

        public async Task<Persona> ObtenerPorDNI(string dni)
        {
            return await _context.Persona
                .FirstOrDefaultAsync(p => p.NroIdentificacionPersona == dni);
        }

        public async Task Crear(Persona persona)
        {
            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Persona persona)
        {
            _context.Persona.Update(persona);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var persona = await _context.Persona.FindAsync(id);
            if (persona != null)
            {
                _context.Persona.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Persona> AutenticarPorContrasenia(string contrasenia)
        {
            return await _context.Persona
                .FirstOrDefaultAsync(p => p.ContraseniaPersona == contrasenia);
        }

        public async Task<List<Eleccion>> ObtenerEleccionesAutorizadas(string dni)
        {
            return await _context.PersonaElecciones
                .Where(pe => pe.Persona.NroIdentificacionPersona == dni && pe.Autorizada)
                .Select(pe => pe.Eleccion)
                .ToListAsync();
        }

    }
}
