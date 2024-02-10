namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DAL;
public interface IEmailService
{
    Task SendLoginCodeAsync(Hotel hotelDTO); 
}
