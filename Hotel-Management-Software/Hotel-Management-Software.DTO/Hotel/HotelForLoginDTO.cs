using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_Software.DTO.Hotel
{
    public class HotelForLoginDTO
    {
        [Required]
        public int LoginCode { get; set; }
        [Required]
        public string Password { get; set; } = null!;
    }
}
