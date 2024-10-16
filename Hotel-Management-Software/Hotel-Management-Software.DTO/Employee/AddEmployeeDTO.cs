﻿namespace Hotel_Management_Software.DTO.Employee;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class AddEmployeeDTO
{
    [Required]
    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string EGN { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public decimal Salary { get; set; }

    [Required]
    public DateTime HieredDate { get; set; }

    [Required]
    public string Role { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public Guid HotelId { get; set; }

    [DefaultValue(true)]
    public bool IsActive { get; set; }
}
