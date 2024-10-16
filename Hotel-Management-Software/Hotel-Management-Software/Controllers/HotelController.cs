namespace Hotel_Management_Software.Controllers;

using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DTO.Hotel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize]
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
        string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var hotelId = await _hotelService.CreateAsync(ownerId, hotelToAddDTO);

        if (hotelId is not null)
        {
            return Ok(new { HotelId = hotelId });
        }

        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(Guid id)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        var hotelDetails = await _hotelService.DetailsAsync(id, userId);

        if (hotelDetails is not null)
        {
            return Ok(hotelDetails);
        }

        return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        string ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var hotels = await _hotelService.GetAllAsync(ownerId);

        if (hotels is not null)
        {
            return Ok(hotels);
        }

        return BadRequest();
    }
}