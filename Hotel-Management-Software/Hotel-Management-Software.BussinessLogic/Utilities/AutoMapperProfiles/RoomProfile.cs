namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;

using AutoMapper;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Room;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Room, RoomToAddDTO>().ReverseMap();

        CreateMap<Room, RoomDTO>().ReverseMap();

        CreateMap<RoomExtra, RoomExtraToAddDTO>().ReverseMap();

        CreateMap<RoomExtraDTO, RoomExtra>().ReverseMap();

        CreateMap<Room, EditRoomDTO>().ReverseMap();
    }
}
