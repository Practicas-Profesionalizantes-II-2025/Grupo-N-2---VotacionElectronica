using Microsoft.AspNetCore.Identity;

namespace Shared.Services
{
    public class SeguridadServicio
    {
        private readonly PasswordHasher<string> _hasher = new();

        public string HashContrasenia(string contrasenia)
        {
            return _hasher.HashPassword(null, contrasenia);
        }

        public bool VerificarContrasenia(string contraseniaIngresada, string hashGuardado)
        {
            var result = _hasher.VerifyHashedPassword(null, hashGuardado, contraseniaIngresada);
            return result == PasswordVerificationResult.Success
                   || result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
