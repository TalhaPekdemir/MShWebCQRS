using Microsoft.AspNetCore.Http;

namespace MShWeb.Application.Features.Product.Commands.Update
{
    public class UpdateProductCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IFormFile>? Images { get; set; }
    }
}
