using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain;

namespace Projeto.Application.Products
{
    public sealed class GetProductsQuery : IQuery<ProductResult[]>
    {

    }
    public sealed class GetProductQuery : IQuery<ProductResult>
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
