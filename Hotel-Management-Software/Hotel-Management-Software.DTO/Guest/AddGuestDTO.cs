using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_Software.DTO.Guest;

public class AddGuestDTO
{
   
    public string? EGN { get; set; }

    public string? IdentityDocumentNumber { get; set; }
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;

    public int Gender { get; set; }
    [Required]
    public string Country { get; set; } = null!;
    [Required]
    public string Address { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string? AdditionalInformation { get; set; }
}
