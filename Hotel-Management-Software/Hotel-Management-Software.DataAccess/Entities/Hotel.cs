namespace Hotel_Management_Software.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;


public class Hotel
{
    [Key]
    public int HotelId { get; set; }

    [Required]
    public string HotelName { get; set; } = null!;

    [Required]
    public string HotelLocation { get; set; } = null!;

    [Required]
    public string HotelTelephoneNumber { get; set; } = null!;

    [Required]
    public byte[] HotelPicture { get; set; } = null!;

    [Required]
    public string HotelEmailAddress { get; set; } = null!;

    [Required]
    public int LoginNumber { get; set; }

    [Required]
    public string HotelPasswordHash { get; set; } = null!;






}

