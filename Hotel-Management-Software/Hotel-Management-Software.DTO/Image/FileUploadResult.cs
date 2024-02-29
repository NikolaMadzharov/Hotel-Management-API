namespace Hotel_Management_Software.DTO.Image;

using System.Net;

public class FileUploadResult
{
    public HttpStatusCode? StatusCode { get; set; }

    public string? PublicId { get; set; }

    public string? SecureUrl { get; set; }
}
