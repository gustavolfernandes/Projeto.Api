using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Products;

namespace Projeto.Api.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{id}")]
        public Task<ProductResult> GetProductById([FromRoute] Guid id, [FromServices] ProductsQueryHandler handler)
            => handler.RunAsync(new GetProductQuery { Id = id});

        [HttpGet]
        public Task<ProductResult[]> GetProducts([FromQuery] GetProductsQuery query, [FromServices] ProductsQueryHandler handler)
            => handler.RunAsync(query);

        [HttpPost]
        public Task PostProducts([FromBody] PostProductCommand command, [FromServices] ProductsCommandHandler handler)
            => handler.RunAsync(command);

        [HttpPut]
        public Task PutProduct([FromBody] PutProductCommand command, [FromServices] ProductsCommandHandler handler)
            => handler.RunAsync(command);

        [HttpDelete("{id}")]
        public Task DeleteProduct([FromRoute] Guid id, [FromServices] ProductsCommandHandler handler)
            => handler.RunAsync(new DeleteProductCommand { Id = id });

    }
}
