namespace Hotel_Management_Software.DAL.Entities.ApplicationUser;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        Hotels = new HashSet<Hotel>();
        SalaryReports = new HashSet<SalaryReport>();
    }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? EGN { get; set; }

    public string Address { get; set; } = null!;

    public decimal? Salary { get; set; }

    [Column(TypeName = "Timestamp")]
    public DateTime? HieredDate { get; set; }

    [Column(TypeName = "Timestamp")]
    public DateTime? TerminationDate { get; set; }

    public Guid? ImageId { get; set; }
    [ForeignKey(nameof(ImageId))]
    public virtual Image? Image { get; set; }

    [DefaultValue(true)]
    public bool IsActive { get; set; }

    [InverseProperty("Owner")]
    public virtual ICollection<Hotel> Hotels { get; set; }

    public Guid? EmployeeHotelId { get; set; }
    [ForeignKey(nameof(EmployeeHotelId))]
    public virtual Hotel? EmployeeHotel { get; set; }

    public virtual ICollection<SalaryReport> SalaryReports { get; set; }
}
