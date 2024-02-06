using Hotel_Management_Software.BussinessLogic.Services.IServices;
using Hotel_Management_Software.DTO.Hotel;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Software.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IHotelService _hotelService;

        public AccountController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost("Register/Hotel")]
        public async Task<IActionResult> Register([FromForm] HotelToAddDTO hotelToAddDTO)
        {
           var result = await _hotelService.RegisterAsync(hotelToAddDTO);

            if (result is true)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
