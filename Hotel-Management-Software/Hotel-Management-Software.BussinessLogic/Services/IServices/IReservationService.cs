using Hotel_Management_Software.DTO.Reservation;

namespace Hotel_Management_Software.BBL.Services.IServices;

public interface IReservationService
{
    Task<Guid> Book(AddReservationDTO addReservationDTO);

    Task<List<CalendarReservationDTO>> GetCalendarBookedDay(Guid roomId);
}
