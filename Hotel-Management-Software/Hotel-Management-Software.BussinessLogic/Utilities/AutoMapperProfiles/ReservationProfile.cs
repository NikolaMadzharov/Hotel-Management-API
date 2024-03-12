namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;
using AutoMapper;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Reservation;

public class ReservationProfile:Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, AddReservationDTO>().ReverseMap();
    }
}
