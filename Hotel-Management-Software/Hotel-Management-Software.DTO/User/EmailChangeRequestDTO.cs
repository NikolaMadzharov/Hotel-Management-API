namespace Hotel_Management_Software.DTO.User;

using System.ComponentModel.DataAnnotations;

public class EmailChangeRequestDTO
{
    [Required]
    [EmailAddress]
    public string NewEmail { get; set; } = null!;
}
