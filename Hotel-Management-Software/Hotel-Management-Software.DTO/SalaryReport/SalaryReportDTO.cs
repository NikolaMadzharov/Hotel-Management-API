namespace Hotel_Management_Software.DTO.SalaryReport;

public class SalaryReportDTO
{
   
    public Guid Id { get; set; }
  
    public bool IsPaid { get; set; }

    public decimal Salary { get; set; }

    public DateTime Date { get; set; }
}
