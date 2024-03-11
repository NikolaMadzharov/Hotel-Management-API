namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Room;

public interface IRoomService
{
    Task<RoomDTO> CreateAsync(RoomToAddDTO roomToAddDTO);

    Task<List<RoomDTO>> GetRoomsByFloorId(Guid floorId);


    Task<List<RoomExtraDTO>> AddRoomExtraAsync(List<RoomExtraToAddDTO> roomExtraToAddDTO);

    Task<RoomDTO> GetRoomByIdAsync(Guid id);

    Task<RoomDTO?> EditAsync(EditRoomDTO editRoomDTO);
}
