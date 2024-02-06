
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace Hotel_Management_Software.DTO.Hotel
{
    public class HotelToAddDTO
    {
        [Required]
        public string HotelName { get; set; } = null!;

        [Required]
        public string HotelLocation { get; set; } = null!;

        [Required]
        public string HotelTelephoneNumber { get; set; } = null!;

        [Required]
        public IFormFile HotelPicture { get; set; } = null!;

        [Required]
        public string HotelEmailAddress { get; set; } = null!;

        [Required]

        public string Password { get; set; } = null!;


    }
}
