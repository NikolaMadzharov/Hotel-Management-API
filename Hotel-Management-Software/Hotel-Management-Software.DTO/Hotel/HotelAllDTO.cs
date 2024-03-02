namespace Hotel_Management_Software.DTO.Hotel;

public class HotelAllDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ProfilePicture { get; set; } = null!;

    public string Address { get; set; } = null!;
}
