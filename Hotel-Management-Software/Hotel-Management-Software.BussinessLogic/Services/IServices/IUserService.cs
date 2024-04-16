namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DTO.User;

public interface IUserService
{
    Task<bool> RegisterAsync(UserToAddDTO userToAddDTO);

    Task<string> LoginAsync(UserLoginDTO userToLoginDTO);

    Task PasswordResetAsync(string username, string resetToken, string newPassword);

    Task ChangePasswordAsync(string userId, ChangePasswordDTO changePasswordDTO);

    Task GenerateChangeEmailTokenAsync(string userId, string newEmail);

    Task ChangeEmailAsync(string userId, EmailChangeDTO emailChangeDTO);
}
