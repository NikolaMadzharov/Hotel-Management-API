namespace Hotel_Management_Software.BBL.Services;

using AutoMapper;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DTO.Hotel;
using System.Threading.Tasks;

public class HotelService : IHotelService
{
    private readonly IMapper _mapper;
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IMapper mapper, IHotelRepository hotelRepository)
    {
        _mapper = mapper;
        _hotelRepository = hotelRepository;
    }

    public async Task<Guid?> CreateAsync(string ownerId, HotelToAddDTO hotelToAdd)
    {
        var hotel = _mapper.Map<Hotel>(hotelToAdd);
        hotel!.OwnerId = ownerId;

        await _hotelRepository.AddAsync(hotel!);

        return hotel.Id;
    }

    public async Task<List<HotelAllDTO>> GetAllAsync(string ownerId)
    {
        var ownerHotels = await _hotelRepository.GetListAsync(x => x.OwnerId == ownerId);

        

       var hotels =  _mapper.Map<List<HotelAllDTO>>(ownerHotels).ToList();



        return hotels;
    }
}
