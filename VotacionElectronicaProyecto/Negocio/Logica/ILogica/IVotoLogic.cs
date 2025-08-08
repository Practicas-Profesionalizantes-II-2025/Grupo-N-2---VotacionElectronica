using Shared.Dtos.Voto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica.ILogica
{
    public interface IVotoLogic
    {
        Task RegistrarVoto(CrearDTO votoDto);
        Task EliminarVoto(int id);

    }
}
