﻿namespace Hotel_Management_Software.BussinessLogic.Utilities.AutoMapperProfiles;
using AutoMapper;
using Hotel_Management_Software.DataAccess.Entities;
using Hotel_Management_Software.DTO.Hotel;

public class HotelProfile : Profile
{

    public HotelProfile()
    {
        CreateMap<Hotel, HotelToAddDTO>().ReverseMap();
    }
}
