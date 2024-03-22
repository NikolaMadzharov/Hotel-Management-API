namespace Hotel_Management_Software.DTO.User;

using System.ComponentModel.DataAnnotations;

public class UserPasswordResetDTO
{
    [Required]
    public string LoginCode { get; set; } = null!;

    [Required]
    public string ResetToken { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;
}
