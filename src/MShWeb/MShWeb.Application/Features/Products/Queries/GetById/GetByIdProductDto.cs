using MShWeb.Application.Features.Images.Dtos;

namespace MShWeb.Application.Features.Products.Queries.GetById
{
    public class GetByIdProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ImageDto> Images { get; set; }
    }
}
