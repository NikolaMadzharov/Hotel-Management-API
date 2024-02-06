


namespace Hotel_Management_Software.BussinessLogic.Helpers;
using Microsoft.AspNetCore.Identity;
public static class PasswordHasher
{
  
    public static string HashPassword(string password)
    {
        var hasher = new PasswordHasher<object>(); 
        return hasher.HashPassword(null, password);
    }

    public static bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var hasher = new PasswordHasher<object>(); // You can specify a type if needed
        var result = hasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
        return result == PasswordVerificationResult.Success;
    }
}
