namespace Hotel_Management_Software.DAL.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Reservation
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid RoomId { get; set; }
    [ForeignKey(nameof(RoomId))]
    public virtual Room Room { get; set; } = null!;

    [Required]
    public Guid GuestId { get; set; }
    [ForeignKey(nameof(GuestId))]
    public virtual Guest Guest { get; set; } = null!;

    [Required]
    [Column(TypeName = "Timestamp")]
    public DateTime From { get; set; }

    [Required]
    [Column(TypeName = "Timestamp")]
    public DateTime To { get; set; }
}
