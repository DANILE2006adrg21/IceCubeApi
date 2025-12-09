using System.Security.Cryptography;
using System.Text;

namespace IceCube.Services
{
    public static class PasswordHelper
    {
        // Genera un hash SHA256 en formato hexadecimal
        public static string Hash(string password)
        {
            using var sha = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha.ComputeHash(bytes);

            return Convert.ToHexString(hash);
        }

        // Compara un password en texto plano contra el hash guardado
        public static bool Verify(string password, string storedHash)
        {
            string hashOfInput = Hash(password);
            return string.Equals(hashOfInput, storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
