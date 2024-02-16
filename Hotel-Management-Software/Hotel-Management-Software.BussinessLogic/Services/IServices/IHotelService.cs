namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DTO.Hotel;
using System.Threading.Tasks;

public interface IHotelService
{
    Task<Guid?> CreateAsync(string ownerId, HotelToAddDTO hotelToAdd);

    Task<List<HotelAllDTO>> GetAllAsync(string ownerId);
}
