namespace Hotel_Management_Software.Controllers;

using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DTO.Floor;
using Hotel_Management_Software.DTO.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class FloorController : Controller
{
    private readonly IFloorService _floorService;
    private readonly IRoomService _roomService;

    public FloorController(IFloorService floorService, IRoomService roomService)
    {
        _floorService = floorService;
        _roomService = roomService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] AddFloorDTO addFloorDTO)
    {
        await  _floorService.CreateAsync(addFloorDTO);

      
            return Ok();
       
    }

    [HttpGet("{HotelId}")]
    public async Task<IActionResult> All(Guid HotelId)
    {
        var floor = await _floorService.GetFloorsByHotelIdAsync(HotelId);

        if (floor is not null)
        {
            return Ok(new {floors =  floor});
        }

        return BadRequest();
    }


}
