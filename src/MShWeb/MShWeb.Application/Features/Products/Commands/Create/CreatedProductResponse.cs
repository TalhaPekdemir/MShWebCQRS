using MShWeb.Application.Features.Images.Commands.Create;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Products.Commands.Create
{
    public class CreatedProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CreatedImageResponse> Images { get; set; }
    }
}
