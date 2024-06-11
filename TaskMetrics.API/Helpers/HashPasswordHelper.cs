using System.Security.Cryptography;
using System.Text;

namespace task_api.TaskMetrics.API.Helpers;

public class HashPasswordHelper
{
    public string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hash;
        }
    }

    public bool VerifyPassword(string password, string userPassword)
    {
        var hashedPassword = HashPassword(password);
    
        return hashedPassword == userPassword;
    }
}