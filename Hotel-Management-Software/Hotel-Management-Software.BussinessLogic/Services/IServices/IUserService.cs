using Hotel_Management_Software.DTO.User;

namespace Hotel_Management_Software.BBL.Services.IServices;

public interface IUserService
{
    Task<bool> RegisterAsync(UserToAddDTO userToAddDTO);

    Task<string> LoginAsync(UserLoginDTO userToLoginDTO);

    Task PasswordResetAsync(string username, string resetToken, string newPassword);
}
