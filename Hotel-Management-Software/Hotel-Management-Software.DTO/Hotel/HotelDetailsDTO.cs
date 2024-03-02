namespace Hotel_Management_Software.DTO.Hotel;

public class HotelDetailsDTO
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string TelephoneNumber { get; set; } = null!;

    public string? ProfilePicture { get; set; }
}
