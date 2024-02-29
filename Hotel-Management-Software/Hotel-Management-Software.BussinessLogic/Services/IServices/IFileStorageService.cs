namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DTO.Image;
using Microsoft.AspNetCore.Http;

public interface IFileStorageService
{
    Task<FileUploadResult> UploadAsync(IFormFile file, string path);
}
