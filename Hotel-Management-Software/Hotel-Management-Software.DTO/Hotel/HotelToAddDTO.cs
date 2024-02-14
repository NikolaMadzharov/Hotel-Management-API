namespace Hotel_Management_Software.DTO.Hotel;

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class HotelToAddDTO
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public string TelephoneNumber { get; set; } = null!;

    [Required]
    public string MobilePhone { get; set; } = null!;

    [Required]
    public IFormFile ProfilePicture { get; set; } = null!;
}
