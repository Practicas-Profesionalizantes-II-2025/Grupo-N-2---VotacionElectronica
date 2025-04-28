using Datos.Context;
using Datos.Repositories.Contracts;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class VotoRepository : Repository<Voto>, IVotoRepository
    {
        public VotoRepository(VotacionContext context) : base(context) { }
    }
}
