using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica
{
    public static class ValidacionesNombres
    {
        public static void ValidarCampoObligatorio(string valor, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException($"El campo {nombreCampo} es obligatorio.");
        }

        public static void ValidarSoloLetrasYEspacios(string valor, string nombreCampo)
        {
            if (!valor.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                throw new ArgumentException($"El campo {nombreCampo} solo puede contener letras y espacios.");
        }
    }
}
