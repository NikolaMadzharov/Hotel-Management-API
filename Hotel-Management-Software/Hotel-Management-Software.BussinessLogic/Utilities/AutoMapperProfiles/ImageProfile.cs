namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;

using AutoMapper;
using CloudinaryDotNet.Actions;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Image;

public class ImageProfile : Profile
{
    public ImageProfile()
    {
        CreateMap<RawUploadResult, FileUploadResult>();

        CreateMap<FileUploadResult, Image>()
            .ForMember(dest => dest.URL, opt => opt.MapFrom(src => src.SecureUrl));
    }
}
