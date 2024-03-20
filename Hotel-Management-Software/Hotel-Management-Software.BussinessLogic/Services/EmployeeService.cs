﻿namespace Hotel_Management_Software.BBL.Services;

using AutoMapper;
using Hotel_Management_Software.BBL.Exceptions;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Hotel_Management_Software.DTO.Employee;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public class EmployeeService : IEmployeeService
{
    private readonly IEmailService _emailService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;

    public EmployeeService(IEmailService emailService,
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IMapper mapper)
    {
        _emailService = emailService;
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task<EmployeeDTO?> CreateAsync(AddEmployeeDTO addEmployeeDTO)
    {
        if (!await _roleManager.RoleExistsAsync(addEmployeeDTO.Role))
        {
            throw new CustomException("Invalid employee role.", 400);
        }

        var employee = _mapper.Map<ApplicationUser>(addEmployeeDTO);

        var result = await _userManager.CreateAsync(employee!);

        if (result.Succeeded)
        {
            // TODO: Send pasword reset link to email address and provide the generated username.
            
            return _mapper.Map<EmployeeDTO>(employee);
        }

        return null;
    }
}
