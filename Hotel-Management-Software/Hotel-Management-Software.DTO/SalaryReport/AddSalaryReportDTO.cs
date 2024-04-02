using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_Software.DTO.SalaryReport;



public class AddSalaryReportDTO
{
    [Required]
    public Guid EmployeeId { get; set; }
}
