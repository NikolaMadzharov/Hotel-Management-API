using AutoMapper;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DTO.Floor;
using Microsoft.Extensions.Logging;

namespace Hotel_Management_Software.BBL.Services
{
    public class FloorService : IFloorService
    {

        private readonly IMapper _mapper;
        private readonly IFloorRepository _floorRepository;
        private readonly ILogger _logger;

        public FloorService(IMapper mapper, IFloorRepository floorRepository, ILogger logger)
        {
            _mapper = mapper;
            _floorRepository = floorRepository;
            _logger = logger;
        }

        public async  Task CreateAsync(AddFloorDTO floorDTO)
        {
            _logger.LogInformation("Mapping FloorDTO to Floor entity...");
            var floor = _mapper.Map<Floor>(floorDTO);
            if (floor != null)
            {
                _logger.LogInformation("Adding Floor entity to repository...");
                await _floorRepository.AddAsync(floor);
                _logger.LogInformation("Floor entity added successfully.");
            }
            else
            {
                _logger.LogError("Mapping failed: Floor entity is null.");
            }



        }

        public async Task<List<FloorDTO>> GetFloorsByHotelIdAsync(Guid hotelId)
        {

            var floor = await _floorRepository.GetListAsync(x => x.HotelId == hotelId);


            var floors =  _mapper.Map<List<FloorDTO>>(floor).ToList();

            return floors;

        }
    }
}
