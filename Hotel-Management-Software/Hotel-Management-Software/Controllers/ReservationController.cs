namespace Hotel_Management_Software.Controllers;

using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities;
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
     var result = await _reservationService.Book(AddReservationDTO);

        if (result is true)
        {
            return Ok(new { result = result });
        }

        return BadRequest();
    }
}
