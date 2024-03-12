namespace Hotel_Management_Software.DAL.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RoomExtra
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid RoomId { get; set; }

    [ForeignKey(nameof(RoomId))]
    public virtual Room? Room { get; set; }
}
