using Hotel_Management_Software.DTO.SalaryReport;

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

    public bool IsActive { get; set; } 

    public decimal Salary { get; set; }

    public virtual ICollection<SalaryReportDTO> SalaryReports { get; set; }

    public Guid HotelId { get; set; }
}
