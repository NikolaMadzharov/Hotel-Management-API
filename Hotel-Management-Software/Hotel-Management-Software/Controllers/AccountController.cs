﻿namespace Hotel_Management_Software.Controllers;

using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DTO.User;
using Microsoft.AspNetCore.Mvc;


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

    [HttpPost("PasswordReset")]
    public async Task<IActionResult> PasswordReset([FromForm] UserPasswordResetDTO userPasswordResetDTO)
    {
        await _userService.
            PasswordResetAsync(userPasswordResetDTO.LoginCode, userPasswordResetDTO.ResetToken, userPasswordResetDTO.Password);

        return Ok();
    }
}
