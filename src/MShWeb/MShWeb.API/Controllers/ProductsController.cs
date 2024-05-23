using MediatR;
using Microsoft.AspNetCore.Mvc;
using MShWeb.Application.Features.Products.Commands.Create;

namespace MShWeb.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);

            return Created("", response);
        }
    }
}
