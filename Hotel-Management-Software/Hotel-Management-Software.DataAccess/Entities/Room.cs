namespace Hotel_Management_Software.DAL.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Room
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public int RoomNumber { get; set; }

    [Required]
    public int Floor { get; set; }

    [Required]
    public Guid HotelId { get; set; }

    [ForeignKey(nameof(HotelId))]
    public virtual Hotel Hotel { get; set; } = null!;
}
