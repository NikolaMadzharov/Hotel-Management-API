namespace Hotel_Management_Software.DTO.Room;

public class RoomDTO
{
    public RoomDTO()
    {
        this.RoomExtras = new HashSet<RoomExtraDTO>();
    }

    public Guid Id { get; set; }

    public int RoomNumber { get; set; }

    public bool IsBooked { get; set; }

    public bool IsCleaned { get; set; }

    public virtual ICollection<RoomExtraDTO> RoomExtras { get; set; }
}
