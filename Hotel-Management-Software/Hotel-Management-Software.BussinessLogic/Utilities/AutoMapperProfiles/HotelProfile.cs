namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;

using AutoMapper;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Hotel;
using Microsoft.AspNetCore.Http;

public class HotelProfile : Profile
{
    public HotelProfile()
    {
        CreateMap<Hotel, HotelToAddDTO>().ReverseMap()
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => ConvertIFormFileToByteArray(src.ProfilePicture)));

        CreateMap<Hotel, HotelDTO>().ReverseMap();
    }

    private byte[] ConvertIFormFileToByteArray(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return ms.ToArray();
            }
        }
        return null;
    }
}
