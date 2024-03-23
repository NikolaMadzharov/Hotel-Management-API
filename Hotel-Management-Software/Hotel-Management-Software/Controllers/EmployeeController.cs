namespace Hotel_Management_Software.Controllers;

using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DTO.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static Hotel_Management_Software.BBL.Constants.RoleConstants;

[Authorize(Roles = $"{OWNER}, {ADMIN}")]
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] AddEmployeeDTO addEmployeeDTO)
    {
        var employee = await _employeeService.CreateAsync(addEmployeeDTO);

        if (employee is null)
        {
            return BadRequest();
        }

        return Ok(new { employee });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByHotel([FromQuery] Guid hotelId)
    {
        var empoyees = await _employeeService.GetAllByHotelAsync(hotelId);

        return Ok(new { empoyees });
    }

    [HttpGet("Roles")]
    public async Task<IActionResult> GetRoles()
    {
        var roles = await _employeeService.GetEmployeeRolesAsync();

        return Ok(new { roles });
    }
}
