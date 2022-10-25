using Projeto.Domain;

namespace Projeto.Application.Products.Services;

public interface IProductsService
{
    Task<Product[]> FindAllAsync();
    Task<Product?> FindByIdAsync(ProductId id);
}

