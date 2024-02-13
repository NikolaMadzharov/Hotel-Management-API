using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Hotel_Management_Software.DAL.Entities.ApplicationUser;

public class ApplicationUser:IdentityUser
{
              
    public string? FirstName { get; set; } 

    public string? MidleName { get; set; } 

    public string? LastName { get; set; } 

    public string? EGN { get; set; } 

    public string Address { get; set; } = null!;

    public byte[] ProfilePicture { get; set; } = null!;

    [DefaultValue(true)]
    public bool IsActive { get; set; } 






}
