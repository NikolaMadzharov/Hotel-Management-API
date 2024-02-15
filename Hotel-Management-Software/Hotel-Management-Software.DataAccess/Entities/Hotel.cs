namespace Hotel_Management_Software.DAL.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Hotel
{
    public Hotel()
    {
        Rooms = new HashSet<Room>();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public string TelephoneNumber { get; set; } = null!;

    [Required]
    public string MobilePhone { get; set; } = null!;

    public byte[]? ProfilePicture { get; set; }

    [Required]
    public string OwnerId { get; set; } = null!;
    [ForeignKey(nameof(OwnerId))]
    public virtual ApplicationUser.ApplicationUser Owner { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; }
}
