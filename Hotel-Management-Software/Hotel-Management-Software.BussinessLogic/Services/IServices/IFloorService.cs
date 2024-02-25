using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Floor;

namespace Hotel_Management_Software.BBL.Services.IServices
{
    public interface IFloorService
    {
        Task<FloorDTO> CreateAsync(AddFloorDTO floorDTO);

        Task<List<FloorDTO>> GetFloorsByHotelIdAsync(Guid hotelId);
    }
}
