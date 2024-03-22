namespace Hotel_Management_Software.DTO.Employee;

public class EmployeeDTO
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string EGN { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;
}
