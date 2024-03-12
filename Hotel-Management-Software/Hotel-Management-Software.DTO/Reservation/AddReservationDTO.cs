using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_Software.DTO.Reservation;

public class AddReservationDTO
{
    public string? EGN { get; set; }

    public string? IdentityDocumentNumber { get; set; }
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;

    public string Gender { get; set; }
    [Required]
    public string Country { get; set; } = null!;
    [Required]
    public string Address { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string? AdditionalInformation { get; set; }

    [Required]
    [Column(TypeName = "Timestamp")]
    public DateTime From { get; set; }

    [Required]
    [Column(TypeName = "Timestamp")]
    public DateTime To { get; set; }

    public Guid RoomId { get; set; }

    public Guid GuestId { get; set; }
}
