namespace Hotel_Management_Software.BBL.Services;

using AutoMapper;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DTO.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

public class CloudinaryService : IFileStorageService
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(IConfiguration configuration, IMapper mapper)
    {
        _configuration = configuration;
        _mapper = mapper;
        _cloudinary = new Cloudinary(_configuration["CLOUDINARY_URL"]);
    }

    public async Task<FileUploadResult> UploadAsync(IFormFile file, string path)
    {
        var uploadParams = new RawUploadParams
        {
            File = new FileDescription(file.FileName, file.OpenReadStream()),
            PublicId = path,
            UniqueFilename = true,
            Overwrite = true,
            Type = "authenticated"
        };

        var result = await _cloudinary.UploadAsync(uploadParams);

        var uploadResult = _mapper.Map<FileUploadResult>(result);

        return uploadResult!;
    }
}
