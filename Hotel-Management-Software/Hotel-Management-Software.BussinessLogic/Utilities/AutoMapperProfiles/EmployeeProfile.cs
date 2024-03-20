namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;

using AutoMapper;
using Hotel_Management_Software.BussinessLogic.Helpers;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Hotel_Management_Software.DTO.Employee;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<ApplicationUser, AddEmployeeDTO>().ReverseMap().ForMember(destination => destination.UserName, opt => opt.MapFrom(src => RandomGenerator.Generate().ToString()));

        CreateMap<ApplicationUser, EmployeeDTO>().ReverseMap();
    }
}
