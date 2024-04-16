namespace Hotel_Management_Software.DTO.User;

using System.ComponentModel.DataAnnotations;

public class EmailChangeDTO
{
    [Required]
    [EmailAddress]
    public string NewEmail { get; set; } = null!;

    [Required]
    public string Token { get; set; } = null!;
}
