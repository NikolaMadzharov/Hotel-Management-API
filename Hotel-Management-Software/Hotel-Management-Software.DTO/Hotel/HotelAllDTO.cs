namespace Hotel_Management_Software.DTO.Hotel;

public class HotelAllDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public byte[]? ProfilePicture { get; set; } = null!;

    public string Address { get; set; } = null!;
}
