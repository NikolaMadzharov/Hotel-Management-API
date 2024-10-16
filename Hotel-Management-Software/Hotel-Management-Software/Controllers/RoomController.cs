﻿namespace Hotel_Management_Software.Controllers;

using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DTO.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
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
        var room = await _roomService.CreateAsync(RoomToAddDTO);

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

    [HttpGet("{roomId}")]
    public async Task<IActionResult> GetRoomById(Guid roomId)
    {
        var room = await _roomService.GetRoomByIdAsync(roomId);

        if (room is not null)
        {
            return Ok(new { room = room });
        }

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromForm] EditRoomDTO editRoomDTO)
    {
        var room = await _roomService.EditAsync(editRoomDTO);

        if (room is null)
        {
            return BadRequest();
        }

        return Ok(new { room });
    }

    [HttpPost("AddExtra")]
    public async Task<IActionResult> AddExtra(List<RoomExtraToAddDTO> roomExtraToAddDTO)
    {
        var roomExtra = await _roomService.AddRoomExtraAsync(roomExtraToAddDTO);

        if (roomExtra is not null)
        {
            return Ok(new { roomExtra });
        }

        return BadRequest();
    }


}
