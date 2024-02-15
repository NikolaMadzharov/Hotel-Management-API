namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;

using AutoMapper;
using Hotel_Management_Software.BBL.Helpers;
using Hotel_Management_Software.BussinessLogic.Helpers;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Hotel_Management_Software.DTO.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ApplicationUser, UserToAddDTO>().ReverseMap().ForMember(destination => destination.UserName, opt => opt.MapFrom(src => RandomGenerator.Generate().ToString()))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => FileHelper.ConvertIFormFileToByteArray(src.ProfilePicture)));


    }
}
