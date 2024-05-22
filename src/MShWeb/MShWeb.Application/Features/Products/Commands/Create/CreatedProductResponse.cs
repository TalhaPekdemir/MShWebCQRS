using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Products.Commands.Create
{
    public class CreatedProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Image> Images { get; set; }
    }
}
