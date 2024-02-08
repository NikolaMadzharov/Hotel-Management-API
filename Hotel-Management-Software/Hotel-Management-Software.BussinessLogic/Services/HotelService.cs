namespace Hotel_Management_Software.BussinessLogic.Services;
using Hotel_Management_Software.BussinessLogic.Helpers;
using Hotel_Management_Software.BussinessLogic.Services.IServices;
using Hotel_Management_Software.DAL;
using Hotel_Management_Software.DataAccess.Repositories.IRepositories;
using Hotel_Management_Software.DTO.Hotel;
using Microsoft.Extensions.Configuration;

public class HotelService : IHotelService
{
    
    private readonly IHotelRepository _hotelRepository;
    private readonly IConfiguration _configuration;

    public HotelService(IHotelRepository hotelRepository, 
        IConfiguration configuration)
    {
        _hotelRepository = hotelRepository;
        _configuration = configuration;
    }

    public async Task<string> LoginAsync(HotelForLoginDTO loginHotelDTO)
    {
       
      

       
        var hotel = await _hotelRepository.GetAsync(x => x.LoginNumber == loginHotelDTO.LoginCode);

        var IsSame = PasswordHasher.VerifyPassword(hotel.HotelPasswordHash, loginHotelDTO.Password);

        if (IsSame == false) 
        {
            return "1";
        }

        var token = JwtHelper.GenerateToken(hotel, _configuration);

        return token;
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
            LoginNumber = RandomGenerator.Generate(),


        };

       await _hotelRepository.AddAsync(HotelToAddDTO);

        return true;
    }
}
