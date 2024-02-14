namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;

using AutoMapper;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Hotel;

public class HotelProfile : Profile
{
    public HotelProfile()
    {
        CreateMap<Hotel, HotelToAddDTO>().ReverseMap();
    }
}
