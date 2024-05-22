using Microsoft.AspNetCore.Http;
using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;
using System.Linq.Expressions;
using MShWeb.Application.Services.Helpers;

namespace MShWeb.Application.Services.Images
{
    public class ImageManager : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageManager(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public Task<Image> CreateAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Image>> CreateManyAsync(List<IFormFile> files, Guid productId)
        {
            var createdImages = await SaveFilesAsync(files);

            foreach (var image in createdImages)
            {
                image.ProductId = productId;
            }

            await _imageRepository.CreateManyAsync(createdImages);

            return createdImages;
        }

        public Task<Image> DeleteAsync(Image image, bool isSoft)
        {
            throw new NotImplementedException();
        }

        public Task<List<Image>> GetAllAsync(Expression<Func<Image, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetAsync(Expression<Func<Image, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Image> UpdateAsync(Image image)
        {
            throw new NotImplementedException();
        }

        



        private async Task<Image> SaveFileAsync(IFormFile file)
        {
            // requirements: path, filename, extension
            // don't trust filename genrate guid
            // dont trust extension, can be different but can't be bothered to check right now
            // file.ContentType maybe???
            // get path somehow better

            string path = HttpContextHelper.Env.WebRootPath + "uploads";
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName);

            EnsureDirectoryExists(path);

            string pathToSave = Path.Combine(path, fileName, extension);
            using (FileStream stream = File.Create(pathToSave))
            {
                await file.CopyToAsync(stream);
            }

            return new Image()
            {
                CreatedDate = DateTime.UtcNow,
                Source = fileName + extension,
            };
        }


        private async Task<List<Image>> SaveFilesAsync(List<IFormFile> files)
        {
            List<Image> images = new List<Image>();

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    Image image = await SaveFileAsync(file);
                    images.Add(image);
                }
            }

            return images;
        }

        private void EnsureDirectoryExists(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }
    }
}
