namespace Hotel_Management_Software.BBL.Services;

using AutoMapper;
using Hotel_Management_Software.BBL.Exceptions;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Hotel_Management_Software.DTO.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using static Constants.RoleConstants;

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
        if (!await _roleManager.RoleExistsAsync(addEmployeeDTO.Role) || addEmployeeDTO.Role == OWNER)
        {
            throw new CustomException("Invalid employee account type.", 400);
        }

        var employee = _mapper.Map<ApplicationUser>(addEmployeeDTO);

        var result = await _userManager.CreateAsync(employee!);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(employee!, addEmployeeDTO.Role);

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(employee!);

            await _emailService.SendResetLinkAsync(employee!, resetToken);

            return _mapper.Map<EmployeeDTO>(employee);
        }

        return null;
    }

    public async Task<string[]> GetEmployeeRolesAsync()
    {
        string?[] roles = await _roleManager.Roles.Where(r => r.Name != OWNER).Select(r => r.Name).ToArrayAsync();

        return roles;
    }
}
