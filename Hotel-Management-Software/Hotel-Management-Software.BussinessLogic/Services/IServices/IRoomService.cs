namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Room;

public interface IRoomService
{
    Task<RoomDTO> CreateAsync(RoomToAddDTO roomToAddDTO);

    Task<List<RoomDTO>> GetRoomsByFloorId(Guid floorId);


    Task<RoomExtraToAddDTO> AddRoomExtraAsync(RoomExtraToAddDTO roomExtraToAddDTO);

    Task<Room> GetRoomByIdAsync(Guid id);

}
