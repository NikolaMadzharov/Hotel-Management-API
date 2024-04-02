namespace Hotel_Management_Software.Controllers;

using Hotel_Management_Software.BBL.Constants;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DTO.SalaryReport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize/*(Roles = RoleConstants.ACCOUNTANT)*/]
[Route("api/[controller]")]
[ApiController]
public class SalaryReportController : Controller
{
    private readonly ISalaryReportService _salaryReportService;

    public SalaryReportController(ISalaryReportService salaryReportService)
    {
        _salaryReportService = salaryReportService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] AddSalaryReportDTO addSalaryReportDTO)
    {
        var salaryReport = await _salaryReportService.AddAsync(addSalaryReportDTO);

        if (salaryReport is true)
        {
            return Ok(new { salaryReport });
        }

        return BadRequest();
    }
}
