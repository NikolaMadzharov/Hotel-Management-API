namespace Hotel_Management_Software.DTO.Room;

using System.ComponentModel.DataAnnotations;

public class EditRoomDTO
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public int RoomNumber { get; set; }

    [Required]
    public Guid FloorId { get; set; }

    [Required]
    public bool IsCleaned { get; set; }
}