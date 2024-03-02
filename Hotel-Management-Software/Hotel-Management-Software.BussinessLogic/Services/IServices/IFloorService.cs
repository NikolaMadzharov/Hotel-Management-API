namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DTO.Floor;

public interface IFloorService
{
    Task<FloorDTO> CreateAsync(AddFloorDTO floorDTO);

    Task<List<FloorDTO>> GetFloorsByHotelIdAsync(Guid hotelId);

    Task DeleteAsync(Guid floorId);
}
