using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.UploadImage
{
    public class UploadImage : IUploadImage
    {
        private readonly IConfiguration _configuration;
        
        public UploadImage(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public async Task<Image> UploadImageOnCloudinary(IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    var cloudName = _configuration["Cloudinary:CloudName"];
                    var apiKey = _configuration["Cloudinary:ApiKey"];
                    var apiSecret = _configuration["Cloudinary:ApiSecret"];

                    Account account = new Account(cloudName, apiKey, apiSecret);
                    Cloudinary cloudinary = new Cloudinary(account);

                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.FileName, stream)
                        };
                        var uploadResult = await cloudinary.UploadAsync(uploadParams);

                        return new Image
                        {
                            ImageUrl = uploadResult.Url.ToString(),
                            PublicId = uploadResult.PublicId
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while uploading the image: {ex.Message}");
                    throw;
                }
            }

            return null;
        }

        public async Task<ICollection<Image>> UploadImagesOnCloudinary(IEnumerable<IFormFile> files)
        {
            var images = new List<Image>();

            if (files != null)
            {
                try
                {
                    var cloudName = _configuration["Cloudinary:CloudName"];
                    var apiKey = _configuration["Cloudinary:ApiKey"];
                    var apiSecret = _configuration["Cloudinary:ApiSecret"];

                    Account account = new Account(cloudName, apiKey, apiSecret);
                    Cloudinary cloudinary = new Cloudinary(account);

                    foreach (var file in files)
                    {
                        using (var stream = file.OpenReadStream())
                        {
                            var uploadParams = new ImageUploadParams()
                            {
                                File = new FileDescription(file.FileName, stream)
                            };
                            var uploadResult = await cloudinary.UploadAsync(uploadParams);

                            var image = new Image
                            {
                                ImageUrl = uploadResult.Url.ToString(),
                                PublicId = uploadResult.PublicId
                            };

                            images.Add(image);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while uploading images: {ex.Message}");
                    throw;
                }
            }

            return images;
        }
        public async Task DeleteImageFromCloudinary(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            var cloudName = _configuration["Cloudinary:CloudName"];
            var apiKey = _configuration["Cloudinary:ApiKey"];
            var apiSecret = _configuration["Cloudinary:ApiSecret"];

            Account account = new Account(cloudName, apiKey, apiSecret);
            Cloudinary cloudinary = new Cloudinary(account);

            var result = await cloudinary.DestroyAsync(deletionParams);

            if (result.Result != "ok")
            {
                throw new Exception($"Failed to delete image with PublicId: {publicId}");
            }
        }
    }
}

