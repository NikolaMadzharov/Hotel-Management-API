using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_Software.DTO.User;

public class UserLoginDTO
{
    [Required]
    public string LoginCode { get; set; }
    [Required]
    public string Password { get; set; }
}
