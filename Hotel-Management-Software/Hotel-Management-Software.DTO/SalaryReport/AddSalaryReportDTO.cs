namespace Hotel_Management_Software.DTO.SalaryReport;

using System.ComponentModel.DataAnnotations;

public class AddSalaryReportDTO
{
    [Required]
    public Guid EmployeeId { get; set; }
}
