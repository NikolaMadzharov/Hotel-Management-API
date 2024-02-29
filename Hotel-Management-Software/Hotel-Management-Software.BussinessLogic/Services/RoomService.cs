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

    public RoomService(IMapper mapper, IRoomRepository roomRepository)
    {
        _mapper = mapper;
        _roomRepository = roomRepository;
    }

    public async Task<RoomDTO> CreateAsync(RoomToAddDTO roomToAddDTO)
    {
        var room = _mapper.Map<Room>(roomToAddDTO);

        await _roomRepository.AddAsync(room!);

        var roomDTO = _mapper.Map<RoomDTO>(room);

        return roomDTO;

      
    }

    public async   Task<Room> GetRoomByIdAsync(Guid id)
    {
        var room = await _roomRepository.GetAsync(x => x.Id == id);

        return room;
    }

    public async Task<List<RoomDTO>> GetRoomsByFloorId(Guid floorId)
    {
       var rooms = await _roomRepository.GetListAsync(x => x.FloorId == floorId);

        var sortedRooms = rooms.OrderBy(x => x.RoomNumber).ToList(); 

        var roomsDTO = _mapper.Map<List<RoomDTO>>(sortedRooms).ToList();

        return roomsDTO;
    }
}
