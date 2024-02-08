namespace Hotel_Management_Software.DTO.Hotel;
using System.ComponentModel.DataAnnotations;




public class HotelForLoginDTO
{
    [Required]
    public int LoginCode { get; set; }
    [Required]
    public string Password { get; set; } = null!;
}
