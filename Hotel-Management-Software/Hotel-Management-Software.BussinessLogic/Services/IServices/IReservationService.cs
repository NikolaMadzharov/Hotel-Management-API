using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Reservation;

namespace Hotel_Management_Software.BBL.Services.IServices;

public interface IReservationService
{
    Task<Guid> BookAsync(AddReservationDTO addReservationDTO);

    Task<List<ReservationDTO>> GetAllReservationsByRoomAsync(Guid roomId);

    Task<ReservationDTO> GetReservationAsync(Guid reservationId);

    Task<List<CalendarReservationDTO>> GetCalendarBookedDayAsync(Guid roomId);
}
