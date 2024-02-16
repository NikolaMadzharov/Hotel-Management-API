namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DTO.Hotel;

public interface IHotelService
{
    Task<HotelDTO?> CreateAsync(string ownerId, HotelToAddDTO hotelToAdd);

    Task<HotelDetailsDTO?> DetailsAsync(Guid hotelId, string currentUserId);
}
