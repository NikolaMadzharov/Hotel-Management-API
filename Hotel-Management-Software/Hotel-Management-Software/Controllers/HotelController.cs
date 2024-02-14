namespace Hotel_Management_Software.Controllers;

using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DTO.Hotel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class HotelController : Controller
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] HotelToAddDTO hotelToAddDTO)
    {
        // Temp hardcode for testing. Remove
        string ownerId = "08bdb28a-47a7-48fd-bb7e-95b02f3724bc"; //User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var hotel = await _hotelService.CreateAsync(ownerId, hotelToAddDTO);

        if (hotel is not null)
        {
            return Ok(hotel);
        }

        return BadRequest();
    }
}
