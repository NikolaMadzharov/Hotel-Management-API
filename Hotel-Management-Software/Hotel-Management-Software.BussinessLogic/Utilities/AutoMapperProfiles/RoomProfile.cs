namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;

using AutoMapper;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Hotel;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Hotel, HotelToAddDTO>().ReverseMap();

        CreateMap<Hotel, HotelDTO>().ReverseMap();
    }
}
