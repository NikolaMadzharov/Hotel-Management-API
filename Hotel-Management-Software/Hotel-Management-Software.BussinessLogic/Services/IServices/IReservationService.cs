using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Reservation;

namespace Hotel_Management_Software.BBL.Services.IServices;

public interface IReservationService
{
    Task<Guid> Book(AddReservationDTO addReservationDTO);

    Task<List<ReservationDTO>> GetAllReservationsByRoom(Guid id);

    Task<List<CalendarReservationDTO>> GetCalendarBookedDay(Guid roomId);
}
