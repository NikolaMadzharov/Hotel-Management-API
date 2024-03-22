namespace Hotel_Management_Software.DTO.Reservation;

public class ReservationDTO
{
    public Guid Id { get; set; }

    public virtual GuestDTO Guest { get; set; } 

    public DateTime From { get; set; }

    public DateTime To { get; set; }
}
