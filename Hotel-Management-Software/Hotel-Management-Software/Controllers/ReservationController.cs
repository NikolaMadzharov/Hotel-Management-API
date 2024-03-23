namespace Hotel_Management_Software.Controllers;

using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DTO.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ReservationController : Controller
{
     private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpPost]
    public async Task<IActionResult> Book([FromForm] AddReservationDTO AddReservationDTO)
    {
     var result = await _reservationService.BookAsync(AddReservationDTO);

        if (result != Guid.Empty)
        {
            return Ok(new { Id = result });
        }

        return BadRequest();
    }

    [HttpGet("Calendar/{roomId}")]
    public async Task<IActionResult> GetCaledarBookedDays(Guid roomId)
    {
        var result = await _reservationService.GetCalendarBookedDayAsync(roomId);

        if (result.Any())
        {
            return Ok(new { BookedDates = result });
        }

        return BadRequest();
    }


    [HttpGet("room/{roomId}")]
    public async Task<IActionResult> GetAllReservations(Guid roomId)
    {
        var result = await _reservationService.GetAllReservationsByRoomAsync(roomId);

        if (result is not null)
        {
            return Ok(new { ALlReservations = result });
        }

        return BadRequest();
    }


    [HttpGet("{reservationId}")]
    public async Task<IActionResult> GetReservation(Guid reservationId)
    {
        var result = await _reservationService.GetReservationAsync(reservationId);

        if (result is not null)
        {
            return Ok(new { reservation = result });
        }

        return BadRequest("Invalid reservation");
    }
}
