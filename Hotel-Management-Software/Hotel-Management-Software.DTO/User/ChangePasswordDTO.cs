﻿namespace Hotel_Management_Software.DTO.User;

using System.ComponentModel.DataAnnotations;

public class ChangePasswordDTO
{
    [Required]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Compare("NewPassword")]
    public string ConfirmPassword { get; set; } = null!;
}
