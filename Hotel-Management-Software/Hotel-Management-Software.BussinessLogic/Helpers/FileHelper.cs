namespace Hotel_Management_Software.BBL.Helpers;

using Microsoft.AspNetCore.Http;

public static class FileHelper
{
    public static byte[]? ConvertIFormFileToByteArray(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            using MemoryStream ms = new();

            file.CopyTo(ms);
            return ms.ToArray();
        }
        return null;
    }
}
