namespace Hotel_Management_Software.DAL.Entities.ApplicationUser;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

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

    public byte[] ProfilePicture { get; set; } = null!;

    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; }
}
