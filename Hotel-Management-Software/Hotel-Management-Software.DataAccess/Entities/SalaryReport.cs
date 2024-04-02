namespace Hotel_Management_Software.DAL.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SalaryReport
{
    public SalaryReport()
    {
        Date = DateTime.UtcNow;
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    public bool IsPaid { get; set; }

    [Required]
    [Column(TypeName = "Timestamp")]
    public DateTime Date { get; set; }

    [Required]
    public decimal Salary { get; set; }

    [Required]
    public string EmployeeId { get; set; } = null!;
    [ForeignKey(nameof(EmployeeId))]
    public virtual ApplicationUser.ApplicationUser Employee { get; set; } = null!;
}
