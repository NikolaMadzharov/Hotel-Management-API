using AutoMapper;
using Hotel_Management_Software.BussinessLogic.Helpers;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Hotel_Management_Software.DTO.User;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ApplicationUser, UserToAddDTO>().ReverseMap().ForMember(destination => destination.UserName, opt => opt.MapFrom(src => RandomGenerator.Generate().ToString()))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => ConvertIFormFileToByteArray(src.ProfilePicture)));


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
