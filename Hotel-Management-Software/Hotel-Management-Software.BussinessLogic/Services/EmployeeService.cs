﻿namespace Hotel_Management_Software.BBL.Services;

using AutoMapper;
using Hotel_Management_Software.BBL.Exceptions;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DTO.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using static Constants.RoleConstants;

public class EmployeeService : IEmployeeService
{
    private readonly IEmailService _emailService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmailService emailService,
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _emailService = emailService;
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<EmployeeDTO?> ActivateAccount(Guid employeeId)
    {
        var employee = await _userRepository.GetAsync(x => x.Id == employeeId.ToString());

        if (employee is null)
        {
            throw new CustomException("Invalid employee!", 400);
        }

        if (employee.IsActive)
        {
            throw new CustomException("This account is already activated!", 400);
        }

        employee.IsActive = true;
        await _userRepository.UpdateAsync(employee);

        var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
        employeeDTO!.Roles = await _userManager.GetRolesAsync(employee!);

        return employeeDTO;
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

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            employeeDTO!.Roles = await _userManager.GetRolesAsync(employee!);

            return employeeDTO;
        }

        return null;
    }

    public async Task<EmployeeDTO?> DeactivateAccount(Guid employeeId)
    {
        var employee =  await _userRepository.GetAsync(x => x.Id == employeeId.ToString());

        if (employee is null)
        {
            throw new CustomException("Invalid employee!", 400);
        }

        if (employee.IsActive == false)
        {
            throw new CustomException("This account is already deactivated!", 400);
        }

        employee.IsActive = false;
        await _userRepository.UpdateAsync(employee);

        var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
        employeeDTO!.Roles = await _userManager.GetRolesAsync(employee!);

        return employeeDTO;
    }

    public async Task<EmployeeDTO?> EditAsync(EditEmployeeDTO editEmployeeDTO)
    {
        var employee = await _userRepository.GetAsync(e => e.Id == editEmployeeDTO.Id) ?? throw new KeyNotFoundException();

        employee.FirstName = editEmployeeDTO.FirstName;
        employee.MiddleName = editEmployeeDTO.MiddleName;
        employee.LastName = editEmployeeDTO.LastName;
        employee.EGN = editEmployeeDTO.EGN;
        employee.Address = editEmployeeDTO.Address;
        employee.Email = editEmployeeDTO.Email;
        employee.Salary = editEmployeeDTO.Salary;
        employee.EmployeeHotelId = editEmployeeDTO.HotelId;

        _ = await _userRepository.UpdateAsync(employee!);

        var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
        employeeDTO!.Roles = await _userManager.GetRolesAsync(employee!);

        return employeeDTO;
    }

    public async Task<List<EmployeeShortDTO>?> GetAllByHotelAsync(Guid hotelId)
    {
        var hotelEmployees = await _userRepository.GetListAsync(u => u.EmployeeHotelId == hotelId);

        List<EmployeeShortDTO>? employees = [];

        foreach (var employee in hotelEmployees)
        {
            employees.Add(new EmployeeShortDTO
            {
                Id = employee.Id,
                FirstName = employee.FirstName!,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName!,
                Roles = await _userManager.GetRolesAsync(employee),
                IsActive = employee.IsActive
            });
        }

        return employees;
    }

    public async Task<EmployeeDTO?> GetAnEmployeeById(Guid employeeId)
    {
        var employee = await _userRepository.GetAsync(x => x.Id == employeeId.ToString());

        if (employee is null)
        {
            throw new CustomException("Invalid employee!", 400);
        }

        var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

        employeeDTO!.Roles = await _userManager.GetRolesAsync(employee);

        return employeeDTO;
    }

    public async Task<string?[]> GetEmployeeRolesAsync()
    {
        string?[] roles = await _roleManager.Roles.Where(r => r.Name != OWNER).Select(r => r.Name).ToArrayAsync();

        return roles;
    }
}
