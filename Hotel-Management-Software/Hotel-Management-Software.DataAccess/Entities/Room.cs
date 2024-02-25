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
    public Guid FloorId { get; set; }

    [ForeignKey(nameof(FloorId))]
    public virtual Floor Floor { get; set; } = null!;
}
