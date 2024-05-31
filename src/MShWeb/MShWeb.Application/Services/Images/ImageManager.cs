using Microsoft.AspNetCore.Http;
using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;
using System.Linq.Expressions;
using MShWeb.Application.Services.Files;
using AutoMapper;


namespace MShWeb.Application.Services.Images
{
    public class ImageManager : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public ImageManager(IImageRepository imageRepository, IFileService fileService, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public Task<Image> CreateAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Image>> CreateManyAsync(List<IFormFile> files, Guid productId)
        {
            // save files first
            List<FileInfo> fileInfos = (List<FileInfo>)await _fileService.SaveFilesAsync(files);

            // map from fileinfo to image entity 
            List<Image> images = _mapper.Map<List<Image>>(fileInfos);

            // add same product id for one to many
            foreach (var image in images)
            {
                image.ProductId = productId;
            }

            // save to db
            await _imageRepository.CreateManyAsync(images);

            return images;
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
    }
}
