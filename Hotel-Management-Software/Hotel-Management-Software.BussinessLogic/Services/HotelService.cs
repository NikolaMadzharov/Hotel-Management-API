namespace Hotel_Management_Software.BBL.Services;

using AutoMapper;
using Hotel_Management_Software.BBL.Exceptions;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DTO.Hotel;
using System;
using System.Net;
using System.Threading.Tasks;

public class HotelService : IHotelService
{
    private readonly IMapper _mapper;
    private readonly IHotelRepository _hotelRepository;
    private readonly IFileStorageService _storageService;


    public HotelService(
        IMapper mapper, 
        IHotelRepository hotelRepository, 
        IFileStorageService storageService)
    {
        _mapper = mapper;
        _hotelRepository = hotelRepository;
        _storageService = storageService;
    }

    public async Task<Guid?> CreateAsync(string ownerId, HotelToAddDTO hotelToAdd)
    {
        var hotel = _mapper.Map<Hotel>(hotelToAdd);
        hotel!.OwnerId = ownerId;

        await _hotelRepository.AddAsync(hotel!);

        var imageUploadResult = await _storageService.UploadAsync(hotelToAdd.ProfilePicture, $"Hotels/{hotel.Id}/{Guid.NewGuid()}");

        if (imageUploadResult.StatusCode == HttpStatusCode.OK)
        {
            var image = _mapper.Map<Image>(imageUploadResult);
            hotel.Image = image!;

            _ = _hotelRepository.UpdateAsync(hotel);
        }

        return hotel.Id;
    }

    public async Task<HotelDetailsDTO?> DetailsAsync(Guid hotelId, string currentUserId)
    {
        var hotel = await _hotelRepository.GetAsync(h => h.Id == hotelId) ?? throw new CustomException("Not found.", 404);

        if (hotel.OwnerId != currentUserId)
        {
            throw new CustomException("Not resource owner.", 403);
        }

        var hotelDetails = _mapper.Map<HotelDetailsDTO>(hotel);

        return hotelDetails;
    }
    
    public async Task<List<HotelAllDTO>> GetAllAsync(string ownerId)
    {
        var ownerHotels = await _hotelRepository.GetListAsync(x => x.OwnerId == ownerId);

        

       var hotels =  _mapper.Map<List<HotelAllDTO>>(ownerHotels).ToList();



        return hotels;
    }
}
