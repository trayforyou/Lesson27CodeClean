using Lesson27.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Lesson27.Services
{
    public class HasherSHA256 : IHasher
    {
        public string GetHash(string rawValue)
        {
            if (string.IsNullOrEmpty(rawValue))
                throw new ArgumentNullException(nameof(rawValue));

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(rawValue);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}