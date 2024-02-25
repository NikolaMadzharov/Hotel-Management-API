namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DTO.Room;

public interface IRoomService
{
    Task CreateAsync(RoomToAddDTO roomToAddDTO);

    Task<List<RoomDTO>> GetRoomsByFloorId(Guid floorId);
}
