namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DTO.Hotel;
using System.Threading.Tasks;

public interface IHotelService
{
    Task<HotelDTO?> CreateAsync(string ownerId, HotelToAddDTO hotelToAdd);

    Task<HotelDetailsDTO?> DetailsAsync(Guid hotelId, string currentUserId);

    Task<List<HotelAllDTO>> GetAllAsync(string ownerId);
}
