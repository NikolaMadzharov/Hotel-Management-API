namespace Hotel_Management_Software.DAL.Entities;

using Hotel_Management_Software.DAL.Enumerators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

[Index(nameof(EGN), IsUnique = true)]
[Index(nameof(IdentityDocumentNumber), IsUnique = true)]
public class Guest
{
    public Guest()
    {
        this.Reservations = new HashSet<Reservation>();
    }

    [Key]
    public Guid Id { get; set; }

    public string? EGN { get; set; }

    public string? IdentityDocumentNumber { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public Gender Gender { get; set; }

    public string Country { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string? AdditionalInformation { get; set; }

    [DefaultValue(false)]
    public bool IsDeleted { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; }
}
