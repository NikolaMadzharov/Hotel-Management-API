namespace Hotel_Management_Software.DTO.Hotel;


public class HotelDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string TelephoneNumber { get; set; } = null!;

    public string MobilePhone { get; set; } = null!;

    public byte[]? ProfilePicture { get; set; }

    public string OwnerId { get; set; } = null!;
}
