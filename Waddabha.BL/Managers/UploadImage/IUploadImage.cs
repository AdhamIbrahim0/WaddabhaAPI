using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.UploadImage
{
    public interface IUploadImage
    {
         Task<Image> UploadImageOnCloudinary(IFormFile file);
    }
}
