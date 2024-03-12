using Hotel_Management_Software.DTO.Reservation;

namespace Hotel_Management_Software.BBL.Services.IServices;

public interface IReservationService
{
    Task<bool> Book(AddReservationDTO addReservationDTO);
}
