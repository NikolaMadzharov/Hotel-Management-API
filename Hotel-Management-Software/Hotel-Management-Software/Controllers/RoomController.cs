using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Software.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {

            _roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromForm] RoomToAddDTO RoomToAddDTO)
        {
            var room =  await _roomService.CreateAsync(RoomToAddDTO);


            if (room is not null)
            {
                return Ok(new { room = room });

            }
            return BadRequest();
            
          
        }

        [HttpGet("floor/{floorId}")]
        public async Task<IActionResult> AllByFloorId(Guid floorId)
        {
            var rooms = await _roomService.GetRoomsByFloorId(floorId);

            if (rooms is not null)
            {
                return Ok(new { rooms = rooms });

            }


            return BadRequest();
        }
    }
}
