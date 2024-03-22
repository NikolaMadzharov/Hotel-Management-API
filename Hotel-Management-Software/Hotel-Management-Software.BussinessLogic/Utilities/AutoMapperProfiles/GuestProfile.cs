using AutoMapper;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Reservation;

namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;

public class GuestProfile :Profile
{
    public GuestProfile()
    {
        CreateMap<AddReservationDTO, Guest>().ReverseMap();

        CreateMap<GuestDTO, Guest>().ReverseMap();
    }
}
