namespace Hotel_Management_Software.DTO.Room;

using System.ComponentModel.DataAnnotations;

public class RoomToAddDTO
{
    [Required]
    [Range(minimum: 1, maximum: 9999)]
    public int RoomNumber { get; set; }

    [Required]
    public int Floor { get; set; }

    [Required]
    public Guid HotelId { get; set; }
}
