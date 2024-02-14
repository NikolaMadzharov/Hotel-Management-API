using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_Software.DTO.User;

public class UserToAddDTO
{
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? MiddleName { get; set; }
    [Required]
    public string? LastName { get; set; }

    [Required]
    public string? Email { get; set; }
    [Required]
    public string? EGN { get; set; }
    [Required]
    public string Address { get; set; } = null!;
    [Required]
    public IFormFile ProfilePicture { get; set; } = null!;

    [DefaultValue(true)]
    public bool IsActive { get; set; }

    [Required]
    public string Password { get; set; } = null!;
}
