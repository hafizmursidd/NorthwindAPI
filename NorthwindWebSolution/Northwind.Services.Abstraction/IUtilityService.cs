using Microsoft.AspNetCore.Http;

namespace Northwind.Services.Abstraction
{
    public interface IUtilityService
    {
        string UploadSingleFile (IFormFile formFile);
    }
}