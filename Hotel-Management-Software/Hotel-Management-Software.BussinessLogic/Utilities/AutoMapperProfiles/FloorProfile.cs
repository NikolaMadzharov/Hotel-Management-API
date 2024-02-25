using AutoMapper;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Floor;

namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles
{
    public class FloorProfile : Profile
    {
        public FloorProfile()
        {
           CreateMap<Floor, AddFloorDTO>().ReverseMap();
            CreateMap<Floor, FloorDTO>().ReverseMap();
        }
    }
}
