namespace Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;

public interface IEmailService
{
    Task SendLoginCodeAsync(ApplicationUser user);

    Task SendResetLinkAsync(ApplicationUser user, string resetToken);
}
