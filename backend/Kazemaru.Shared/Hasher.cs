using System.Security.Cryptography;
using System.Text;

namespace backend.Helpers;

public static class Hasher
{
    private const char PasswordSeparator = ';';

    public static string HashPassword(string password)
    {
        try
        {
            var salt = RandomSalt();
            var hashData = SHA256.HashData(Encoding.UTF8.GetBytes(password + salt));
            var base64 = Convert.ToBase64String(hashData);

            return $"{base64}{PasswordSeparator}{salt}";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private static string HashPassword(string password, string salt)
    {
        try
        {
            var hashData = SHA256.HashData(Encoding.UTF8.GetBytes(password + salt));
            var base64 = Convert.ToBase64String(hashData);

            return $"{base64}{PasswordSeparator}{salt}";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static bool ComparePassword(string password, string hashedPassword)
    {
        try
        {
            var salt = hashedPassword.Split(PasswordSeparator)[1];
            return HashPassword(password, salt) == hashedPassword;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private static string RandomSalt()
    {
        try
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(128 / 8));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}