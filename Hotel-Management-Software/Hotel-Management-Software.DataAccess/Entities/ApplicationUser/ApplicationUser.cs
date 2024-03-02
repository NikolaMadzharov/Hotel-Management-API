namespace Hotel_Management_Software.DAL.Entities.ApplicationUser;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        Hotels = new HashSet<Hotel>();
    }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? EGN { get; set; }

    public string Address { get; set; } = null!;

    public Guid? ImageId { get; set; }
    [ForeignKey(nameof(ImageId))]
    public virtual Image? Image { get; set; }

    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; }
}
