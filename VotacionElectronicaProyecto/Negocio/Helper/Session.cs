using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Helper
{
    public static class Session
    {
        public static Shared.Entities.Persona? CurrentPersona { get; set; }
    }
}
