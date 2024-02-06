namespace Hotel_Management_Software.BussinessLogic.Services;
using Hotel_Management_Software.BussinessLogic.Helpers;
using Hotel_Management_Software.BussinessLogic.Services.IServices;
using Hotel_Management_Software.DataAccess.Entities;
using Hotel_Management_Software.DataAccess.Repositories.IRepositories;
using Hotel_Management_Software.DTO.Hotel;



public class HotelService : IHotelService
{
    
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<bool> RegisterAsync(HotelToAddDTO createHoteModel)
    {
        using var memoryStream = new MemoryStream();
        await createHoteModel.HotelPicture.CopyToAsync(memoryStream);


        var HotelToAddDTO = new Hotel
        {
            HotelEmailAddress = createHoteModel.HotelEmailAddress,
            HotelLocation = createHoteModel.HotelLocation,
            HotelTelephoneNumber = createHoteModel.HotelTelephoneNumber,
            HotelName = createHoteModel.HotelName,
            HotelPicture = memoryStream.ToArray(),
            HotelPasswordHash = PasswordHasher.HashPassword(createHoteModel.Password),
            LoginNumber = 19121912,


        };

       await _hotelRepository.AddAsync(HotelToAddDTO);

        return true;
    }
}
