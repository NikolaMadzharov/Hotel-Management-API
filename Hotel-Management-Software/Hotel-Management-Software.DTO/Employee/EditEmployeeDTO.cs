namespace Hotel_Management_Software.DTO.Employee;

using System.ComponentModel.DataAnnotations;

public class EditEmployeeDTO
{
    [Required]
    public string Id { get; set; } = null!;

    [Required]
    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string EGN { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public decimal? Salary { get; set; }

    public Guid? HotelId { get; set; }
}
