namespace Hotel_Management_Software.DTO.Employee;

public class EmployeeShortDTO
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public IEnumerable<string>? Roles { get; set; }
}
