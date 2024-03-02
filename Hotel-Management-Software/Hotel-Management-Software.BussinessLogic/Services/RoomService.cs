namespace Hotel_Management_Software.BBL.Services;

using AutoMapper;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DTO.Room;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class RoomService : IRoomService
{
    private readonly IMapper _mapper;
    private readonly IRoomRepository _roomRepository;
    private readonly IRoomExtraRepository _roomExtraRepository;

    public RoomService(IMapper mapper, IRoomRepository roomRepository, IRoomExtraRepository roomExtraRepository)
    {
        _mapper = mapper;
        _roomRepository = roomRepository;
        _roomExtraRepository = roomExtraRepository;
    }

    public async Task<List<RoomExtraDTO>> AddRoomExtraAsync(List<RoomExtraToAddDTO> roomExtrasToAddDTO)
    {
        var addedRoomExtrasDTO = new List<RoomExtraDTO>();

        foreach (var extra in roomExtrasToAddDTO)
        {
            var extraMap = _mapper.Map<RoomExtra>(extra);


            if (!await _roomExtraRepository.ExistAsync(x => x.Name == extra.Name))
            {
                await _roomExtraRepository.AddAsync(extraMap);


                var addedExtraDTO = _mapper.Map<RoomExtraDTO>(extraMap);
                addedRoomExtrasDTO.Add(addedExtraDTO);
            }

            continue;
       
        }

        return addedRoomExtrasDTO;
    }

    public async Task<RoomDTO> CreateAsync(RoomToAddDTO roomToAddDTO)
    {
        var room = _mapper.Map<Room>(roomToAddDTO);

        await _roomRepository.AddAsync(room!);

        var roomDTO = _mapper.Map<RoomDTO>(room);

        return roomDTO;

      
    }

    public async Task<RoomDTO> GetRoomByIdAsync(Guid id)
    {
        var room = await _roomRepository.GetAsync(x => x.Id == id);

        var roomDTO = _mapper.Map<RoomDTO>(room);

        return roomDTO;
    }

    public async Task<List<RoomDTO>> GetRoomsByFloorId(Guid floorId)
    {
       var rooms = await _roomRepository.GetListAsync(x => x.FloorId == floorId);

        var sortedRooms = rooms.OrderBy(x => x.RoomNumber).ToList(); 

        var roomsDTO = _mapper.Map<List<RoomDTO>>(sortedRooms).ToList();

        return roomsDTO;
    }
}
