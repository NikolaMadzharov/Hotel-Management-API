namespace Hotel_Management_Software.DTO.Room;

using System.ComponentModel.DataAnnotations;

public class RoomExtraToAddDTO
{
    [Required]
    public string Name { get; set; } = null!;

    public Guid RoomId { get; set; }
}
