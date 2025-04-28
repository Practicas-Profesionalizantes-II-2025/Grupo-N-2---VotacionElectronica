using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class SeguridadServicio
    {
        public string CrearContrasenia(string numeroIdentificacion)
        {
            var salt = Guid.NewGuid().ToString();
            string contrasenia = numeroIdentificacion + "SomeFixedString" + salt;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));

                // Convertir el resultado a una cadena hexadecimal completa
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }

        }
    }
}
