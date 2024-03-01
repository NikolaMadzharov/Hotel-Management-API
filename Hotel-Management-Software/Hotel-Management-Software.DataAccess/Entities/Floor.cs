using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_Software.DAL.Entities;

public class Floor
{

    public Floor()
    {
        Rooms = new HashSet<Room>();
    }
    public Guid Id { get; set; }

    [Required]
    public int FloorNumber { get; set; }

    public virtual ICollection<Room>? Rooms { get; set; }

   
    public virtual Guid  HotelId { get; set; } 

    [ForeignKey(nameof(HotelId))]
    public virtual Hotel? Hotel { get; set; }

}
