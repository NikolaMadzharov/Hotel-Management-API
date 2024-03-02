using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_Software.DTO.Room;

public class RoomExtraDTO
{
    public string Name { get; set; } = null!;

    public Guid RoomId { get; set; }
}
