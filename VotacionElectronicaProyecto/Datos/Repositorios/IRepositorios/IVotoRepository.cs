using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios.IRepositorios
{
    public interface IVotoRepository
    {
        Task Crear(Voto voto);
        Task Eliminar(int id);
    }
}
