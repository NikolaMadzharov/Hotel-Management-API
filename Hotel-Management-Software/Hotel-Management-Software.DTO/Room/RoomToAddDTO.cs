namespace Hotel_Management_Software.DTO.Room;

using System.ComponentModel.DataAnnotations;

public class RoomToAddDTO
{
    [Required]
    [Range(minimum: 1, maximum: 9999)]
    public int RoomNumber { get; set; }

    public Guid FloorId { get; set; }
}
