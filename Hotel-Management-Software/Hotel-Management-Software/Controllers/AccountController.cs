using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_Software.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] UserToAddDTO userToAddDTO)
        {
            var result = await _userService.RegisterAsync(userToAddDTO);

            if (result is true)
            {
                return Ok(new { Success = result });
            }

            return BadRequest(new { Success = result });
        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] UserLoginDTO userToLoginDTO)
        {

            var result = await _userService.LoginAsync(userToLoginDTO);

            if (result is not null)
            {
                return Ok(new { Success = result });
            }

            return BadRequest(new { Success = result });



        }
    }
}
