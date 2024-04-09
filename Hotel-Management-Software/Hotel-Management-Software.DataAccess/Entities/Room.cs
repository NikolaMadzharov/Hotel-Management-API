namespace Hotel_Management_Software.DAL.Entities;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Room
{
    public Room()
    {
        RoomExtras = new HashSet<RoomExtra>();
        Reservations = new HashSet<Reservation>();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    public int RoomNumber { get; set; }

    [DefaultValue(false)]
    public bool IsBooked { get; set; }

    [DefaultValue(true)]
    public bool IsCleaned { get; set; }

    [Required]
    public decimal PricePerNight { get; set; }
    [Required]
    public int PeopleCapacity { get; set; }

    [Required]
    public Guid FloorId { get; set; }

    [ForeignKey(nameof(FloorId))]
    public virtual Floor Floor { get; set; } = null!;

    public virtual ICollection<RoomExtra> RoomExtras { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; }
}
