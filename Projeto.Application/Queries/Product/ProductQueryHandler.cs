using MediatR;
using Projeto.Application.Products.Services;
using Projeto.Domain;
using Projeto.Infra;

namespace Projeto.Application.Products
{
    [Injectable(LifeTime.Scoped)]
    public sealed class ProductsQueryHandler :
        IRequestHandler<GetProductsQuery, ProductResult[]>,
        IRequestHandler<GetProductQuery, ProductResult>
    {
        public ProductsQueryHandler(IProductsService productsService)
        {
            ProductsService = productsService;
        }

        private IProductsService ProductsService { get; }

        public async Task<ProductResult[]> Handle(GetProductsQuery query)
        {
            var items = await ProductsService.FindAll();
            return items.Select(e => new ProductResult(e)).ToArray();
        }
        public async Task<ProductResult> Handle(GetProductQuery query)
        {
            var id = query.Id.ToType<ProductId>();
            var entity = await ProductsService.FindById(id);
            if (entity is null) throw new AppException("Product not found");

            return new ProductResult(entity);
        }
    }
}
