using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MShWeb.Application.Services.Images;

namespace MShWeb.Application.Features.Images.Commands.Create
{
    public class CreateImageCommand : IRequest<List<CreatedImageResponse>>
    {
        public List<IFormFile> Images { get; set; }
        public Guid ProductId { get; set; }

        public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, List<CreatedImageResponse>>
        {

            private readonly IImageService _imageService;

            private readonly IMapper _mapper;

            public CreateImageCommandHandler(IImageService imageService, IMapper mapper)
            {
                _imageService = imageService;
                _mapper = mapper;
            }

            public async Task<List<CreatedImageResponse>> Handle(CreateImageCommand request, CancellationToken cancellationToken)
            {
                // add rules
                var images = await _imageService.CreateManyAsync(request.Images, request.ProductId);

                return _mapper.Map<List<CreatedImageResponse>>(images);;
            }
        }
    }
}
