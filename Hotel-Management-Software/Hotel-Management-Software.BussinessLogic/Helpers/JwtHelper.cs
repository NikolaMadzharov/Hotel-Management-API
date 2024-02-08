namespace Hotel_Management_Software.BussinessLogic.Helpers;

using Hotel_Management_Software.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


public static class JwtHelper
{

    public static string GenerateToken(Hotel hotel, IConfiguration configuration)
    {
        var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim("HotelId", hotel.HotelId.ToString()),
            new Claim(ClaimTypes.Name, hotel.HotelName),
            new Claim(ClaimTypes.Email, hotel.HotelEmailAddress)
        }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }


}
