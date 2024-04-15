namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;

public interface IEmailService
{
    Task SendLoginCodeAsync(ApplicationUser user);

    Task SendResetLinkAsync(ApplicationUser user, string resetToken);

    Task SendEmailForBookedReservation(Reservation reservation);

    Task SendEmailChangeTokenAsync(ApplicationUser user, string newEmail, string token);
}
