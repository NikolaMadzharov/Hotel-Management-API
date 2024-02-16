﻿namespace Hotel_Management_Software.BBL.Services;

using AutoMapper;
using Hotel_Management_Software.BBL.Exceptions;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DTO.Hotel;
using System;
using System.Threading.Tasks;

public class HotelService : IHotelService
{
    private readonly IMapper _mapper;
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IMapper mapper, IHotelRepository hotelRepository)
    {
        _mapper = mapper;
        _hotelRepository = hotelRepository;
    }

    public async Task<HotelDTO?> CreateAsync(string ownerId, HotelToAddDTO hotelToAdd)
    {
        var hotel = _mapper.Map<Hotel>(hotelToAdd);
        hotel!.OwnerId = ownerId;

        await _hotelRepository.AddAsync(hotel!);

        var hotelDTO = _mapper.Map<HotelDTO?>(hotel);

        return hotelDTO;
    }

    public async Task<HotelDetailsDTO?> DetailsAsync(Guid hotelId, string currentUserId)
    {
        var hotel = await _hotelRepository.GetAsync(h => h.Id == hotelId) ?? throw new CustomException("Not found.", 404);

        if (hotel.OwnerId != currentUserId)
        {
            throw new CustomException("Not resource owner.", 403);
        }

        var hotelDetails = _mapper.Map<HotelDetailsDTO>(hotel);

        return hotelDetails;
    }
}
