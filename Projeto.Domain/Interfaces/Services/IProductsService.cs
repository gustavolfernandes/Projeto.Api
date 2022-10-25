using Projeto.Domain;

namespace Projeto.Application.Products.Services;

public interface IProductsService
{
    Task<Product[]> FindAll();
    Task<Product?> FindById(ProductId id);
}

