namespace Hotel_Management_Software.BussinessLogic.Services.IServices;
using Hotel_Management_Software.DTO.Hotel;

public interface IHotelService
{
    Task<bool> RegisterAsync(HotelToAddDTO createHoteModel);
}
