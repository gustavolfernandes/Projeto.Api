using Projeto.Domain;
using Projeto.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Products
{
    [Injectable(LifeTime.Scoped)]
    public sealed class ProductsQueryHandler : 
        IQueryHandler<GetProductsQuery, ProductResult[]>, 
        IQueryHandler<GetProductQuery, ProductResult>
    {
        public ProductsQueryHandler(IProductsService productsService)
        {
            ProductsService = productsService;
        }

        private IProductsService ProductsService { get; }

        public async Task<ProductResult[]> RunAsync(GetProductsQuery query)
        {
            var items = await ProductsService.FindAllAsync();
            return items.Select(e => new ProductResult(e)).ToArray();
        }
        public async Task<ProductResult> RunAsync(GetProductQuery query)
        {
            var id = query.Id.ToType<ProductId>();
            var entity = await ProductsService.FindByIdAsync(id);
            if (entity is null) throw new AppException("Product not found");

            return new ProductResult(entity);
        }
    }
}
