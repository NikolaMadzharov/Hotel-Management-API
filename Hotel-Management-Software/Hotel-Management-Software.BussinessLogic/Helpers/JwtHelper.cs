namespace Hotel_Management_Software.BussinessLogic.Helpers;

using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


public static class JwtHelper
{

    public static string GenerateToken(ApplicationUser user, IConfiguration configuration, params string[] roles)
    {
        var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);

        var tokenHandler = new JwtSecurityTokenHandler();

        List<Claim> claims =
        [
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim("FullName", $"{user.FirstName} {user.LastName}")
        ];

        if (user.Image is not null)
        {
            claims.Add(new Claim("ProfilePicture", user.Image.URL));
        }

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = configuration["Jwt:Issuer"],
            Audience = configuration["Jwt:Audience"]
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}