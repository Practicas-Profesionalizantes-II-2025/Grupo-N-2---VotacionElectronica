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
    if (id <= 0)
        throw new ArgumentException("El ID de la elección es inválido.", nameof(id));

    var e = await _repositorio.ObtenerPorId(id);
    if (e == null)
        throw new InvalidOperationException("Elección no encontrada.");

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
    if (string.IsNullOrWhiteSpace(nombre))
        throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));

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
    if (string.IsNullOrWhiteSpace(textoBusqueda))
        throw new ArgumentException("El texto de búsqueda es obligatorio.", nameof(textoBusqueda));

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
    if (dto == null)
        throw new ArgumentNullException(nameof(dto), "Los datos de la elección son obligatorios.");
    if (string.IsNullOrWhiteSpace(dto.NombreEleccion))
        throw new ArgumentException("El nombre de la elección es obligatorio.", nameof(dto.NombreEleccion));
    if (dto.CantidadListas < 0)
        throw new ArgumentException("La cantidad de listas no puede ser negativa.", nameof(dto.CantidadListas));
    if (dto.FechaInicioEleccion >= dto.FechaFinEleccion)
        throw new ArgumentException("La fecha de inicio debe ser anterior a la fecha de fin.");

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
    if (id <= 0)
        throw new ArgumentException("El ID de la elección es inválido.", nameof(id));
    if (dto == null)
        throw new ArgumentNullException(nameof(dto), "Los datos de la elección son obligatorios.");
    if (string.IsNullOrWhiteSpace(dto.NombreEleccion))
        throw new ArgumentException("El nombre de la elección es obligatorio.", nameof(dto.NombreEleccion));
    if (dto.CantidadListas < 0)
        throw new ArgumentException("La cantidad de listas no puede ser negativa.", nameof(dto.CantidadListas));
    if (dto.FechaInicioEleccion >= dto.FechaFinEleccion)
        throw new ArgumentException("La fecha de inicio debe ser anterior a la fecha de fin.");


    var existente = await _repositorio.ObtenerPorId(id);
    if (existente == null)
        throw new InvalidOperationException("Elección no encontrada.");

    existente.NombreEleccion = dto.NombreEleccion.Trim();
    existente.DescripcionEleccion = dto.DescripcionEleccion?.Trim();
    existente.CantidadListas = dto.CantidadListas;
    existente.FechaInicioEleccion = dto.FechaInicioEleccion;
    existente.FechaFinEleccion = dto.FechaFinEleccion;

    await _repositorio.Actualizar(existente);
}


public async Task Eliminar(int id)
{
    if (id <= 0)
        throw new ArgumentException("El ID de la elección es inválido.", nameof(id));
    var existente = await _repositorio.ObtenerPorId(id);

    if (existente == null)
        throw new InvalidOperationException("No se puede eliminar: la elección no existe.");

    await _repositorio.Eliminar(id);
}


public async Task AsignarLista(AsignarListaDTO dto)
{
    if (dto == null)
        throw new ArgumentNullException(nameof(dto), "Los datos para asignar la lista son obligatorios.");
    if (dto.EleccionId <= 0)
        throw new ArgumentException("El ID de la elección es inválido.", nameof(dto.EleccionId));
    if (dto.ListaId <= 0)
        throw new ArgumentException("El ID de la lista es inválido.", nameof(dto.ListaId));

    await _repositorio.AsignarLista(dto);
}

public async Task<List<Lista>> ObtenerListasPorEleccion(int id)
{
    if (id <= 0)
        throw new ArgumentException("El ID de la elección es inválido.", nameof(id));

    return await _repositorio.ObtenerListasPorEleccion(id);
}


public async Task RemoverListaDeEleccion(int eleccionId, int listaId)
{
    if (eleccionId <= 0)
        throw new ArgumentException("El ID de la elección es inválido.", nameof(eleccionId));
    if (listaId <= 0)
        throw new ArgumentException("El ID de la lista es inválido.", nameof(listaId));

    await _repositorio.RemoverListaDeEleccion(eleccionId, listaId);
}


public async Task AsignarPersona(AsignarPersonaEleccionDTO dto)
{
    if (dto == null)
        throw new ArgumentNullException(nameof(dto), "Los datos para asignar la persona son obligatorios.");
    if (dto.EleccionId <= 0)
        throw new ArgumentException("El ID de la elección es inválido.", nameof(dto.EleccionId));
    if (dto.PersonaId <= 0)
        throw new ArgumentException("El ID de la persona es inválido.", nameof(dto.PersonaId));

    await _repositorio.AsignarPersona(dto);
}

    }
}