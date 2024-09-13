using Microsoft.AspNetCore.Http;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.UploadImage
{
    public interface IUploadImage
    {
        Task<Image> UploadImageOnCloudinary(IFormFile file);
        Task<ICollection<Image>> UploadImagesOnCloudinary(IEnumerable<IFormFile> files);
    }
}
