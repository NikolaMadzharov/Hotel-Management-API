namespace Hotel_Management_Software.DAL.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Hotel
{
    public Hotel()
    {
        Floors = new HashSet<Floor>();
        Employees = new HashSet<ApplicationUser.ApplicationUser>();
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

    public Guid? ImageId { get; set; }
    [ForeignKey(nameof(ImageId))]
    public virtual Image? Image { get; set; }

    [Required]
    public string OwnerId { get; set; } = null!;
    [ForeignKey(nameof(OwnerId))]
    public virtual ApplicationUser.ApplicationUser Owner { get; set; } = null!;

    public virtual ICollection<Floor> Floors { get; set; }

    [InverseProperty("EmployeeHotel")]
    public virtual ICollection<ApplicationUser.ApplicationUser> Employees { get; set; }
}
