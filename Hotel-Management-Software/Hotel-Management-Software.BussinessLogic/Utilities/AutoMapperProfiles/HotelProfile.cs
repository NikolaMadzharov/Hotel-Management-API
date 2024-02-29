namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;

using AutoMapper;
using Hotel_Management_Software.BBL.Helpers;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Hotel;

public class HotelProfile : Profile
{
    public HotelProfile()
    {
        CreateMap<Hotel, HotelToAddDTO>().ReverseMap()
            .ForMember(dest => dest.Image, opt => opt.Ignore());

        CreateMap<Hotel, HotelDTO>().ReverseMap();

        CreateMap<Hotel, HotelDetailsDTO>().ReverseMap();
        
        CreateMap<Hotel, HotelAllDTO>().ReverseMap().
            ForMember(dest => dest.Email, opt => opt.Ignore())
            .ForMember(dest => dest.OwnerId, opt => opt.Ignore())
            .ForMember(dest => dest.TelephoneNumber, opt => opt.Ignore());
    }
}
