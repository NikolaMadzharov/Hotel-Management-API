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
    private readonly IFloorRepository _floorRepository;

    public RoomService(
        IMapper mapper, 
        IRoomRepository roomRepository, 
        IRoomExtraRepository roomExtraRepository, 
        IFloorRepository floorRepository)
    {
        _mapper = mapper;
        _roomRepository = roomRepository;
        _roomExtraRepository = roomExtraRepository;
        _floorRepository = floorRepository;
    }

    public async Task<List<RoomExtraDTO>> AddRoomExtraAsync(List<RoomExtraToAddDTO> roomExtrasToAddDTO)
    {
        var addedRoomExtrasDTO = new List<RoomExtraDTO>();

        
        var room = await _roomRepository.GetAsync(x => x.Id == roomExtrasToAddDTO[0].RoomId);

      
        foreach (var existingExtra in room.RoomExtras.ToList())
        {
            await _roomExtraRepository.DeleteAsync(existingExtra);
        }

    
        var newRoomExtras = roomExtrasToAddDTO.Select(extra => _mapper.Map<RoomExtra>(extra)).ToList();

        newRoomExtras.ForEach(extra => extra.RoomId = room.Id);

        await _roomExtraRepository.AddRangeAsync(newRoomExtras);

      
        await _roomExtraRepository.UpdateRangeAsync(newRoomExtras);

        addedRoomExtrasDTO = newRoomExtras.Select(extra => _mapper.Map<RoomExtraDTO>(extra)).ToList();

        return addedRoomExtrasDTO;








    }

    public async Task<RoomDTO> CreateAsync(RoomToAddDTO roomToAddDTO)
    {
        var room = _mapper.Map<Room>(roomToAddDTO);

        await _roomRepository.AddAsync(room!);

        var roomDTO = _mapper.Map<RoomDTO>(room);

        return roomDTO;


    }

    public async Task<RoomDTO?> EditAsync(EditRoomDTO editRoomDTO)
    {
        var roomExists = await _roomRepository.ExistAsync(r => r.Id == editRoomDTO.Id);
        var floorExists = await _floorRepository.ExistAsync(f => f.Id == editRoomDTO.FloorId);

        if (!roomExists || !floorExists)
        {
            throw new KeyNotFoundException();
        }

        var room = _mapper.Map<Room>(editRoomDTO);

        _ = await _roomRepository.UpdateAsync(room!);

        var roomDto = _mapper.Map<RoomDTO>(room);

        return roomDto;
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
