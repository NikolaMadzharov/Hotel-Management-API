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
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => FileHelper.ConvertIFormFileToByteArray(src.ProfilePicture)));

        CreateMap<Hotel, HotelDTO>().ReverseMap();

        CreateMap<Hotel, HotelDetailsDTO>().ReverseMap();
    }
}
