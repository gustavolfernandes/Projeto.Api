using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Products;

namespace Projeto.Api.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id, 
                                                        [FromServices] IMediator mediator,
                                                        [FromServices] ILogger<ProductsController> _logger)
        {
            try
            {
                _logger.LogInformation($"Get details by productId: {id}");
                var command = new GetProductQuery { Id = id };
                var result =  await mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductResult[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts([FromServices] IMediator mediator,
                                                        [FromServices] ILogger<ProductsController> _logger)
        {
            try
            {
                _logger.LogInformation($"Get products list");
                var command = new GetProductsQuery();
                var result = await mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostProduct([FromServices] IMediator mediator, [FromBody] PostProductCommand command, [FromServices] ILogger<ProductsController> _logger)
        {
            {
                try
                {
                    _logger.LogInformation($"Creating a product with id: {command.Id}");
                    var result = await mediator.Send(command);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);

                    return BadRequest();
                }
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutProduct([FromServices] IMediator mediator, [FromBody] PutProductCommand command, [FromServices] ILogger<ProductsController> _logger)
        {
            {
                try
                {
                    _logger.LogInformation($"Updating a product with id: {command.Id}");
                    var result = await mediator.Send(command);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);

                    return BadRequest();
                }
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ProductCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProduct([FromServices] IMediator mediator, [FromBody] DeleteProductCommand command, [FromServices] ILogger<ProductsController> _logger)
        {
            {
                try
                {
                    _logger.LogInformation($"Updating a product with id: {command.Id}");
                    var result = await mediator.Send(command);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);

                    return BadRequest();
                }
            }
        }
    }
}
