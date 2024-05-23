using MediatR;
using Microsoft.AspNetCore.Mvc;
using MShWeb.Application.Features.Products.Commands.Create;
using MShWeb.Application.Features.Products.Queries.GetAll;

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

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
