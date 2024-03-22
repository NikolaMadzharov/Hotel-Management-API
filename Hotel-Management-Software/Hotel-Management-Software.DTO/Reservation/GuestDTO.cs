namespace Hotel_Management_Software.DTO.Reservation;

public class GuestDTO
{

   public Guid Id { get; set; }

    public string? EGN { get; set; }

    public string? IdentityDocumentNumber { get; set; }

    public string FirstName { get; set; } = null!;
 
    public string LastName { get; set; } = null!;

    public string Gender { get; set; }

    public string Country { get; set; } = null!;
 
    public string Address { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string? AdditionalInformation { get; set; }
}
