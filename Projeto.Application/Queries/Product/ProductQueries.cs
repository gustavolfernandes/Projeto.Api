using MediatR;
using Projeto.Domain;

namespace Projeto.Application.Products
{
    public sealed class GetProductsQuery : IRequest<ProductResult[]>
    {

    }
    public sealed class GetProductQuery : IRequest<ProductResult>
    {
        public Guid Id { get; set; }
    }

    public sealed class ProductResult
    {
        public ProductResult(Product entity)
        {
            Id = entity.Id.Guid;
            Name = entity.Name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
