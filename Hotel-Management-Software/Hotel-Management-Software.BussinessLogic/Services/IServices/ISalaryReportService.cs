using Hotel_Management_Software.DTO.SalaryReport;

namespace Hotel_Management_Software.BBL.Services.IServices;



public interface ISalaryReportService
{
   Task<bool> AddAsync(AddSalaryReportDTO addSalaryReportDTO);  
}
