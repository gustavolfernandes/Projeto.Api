using Microsoft.EntityFrameworkCore;
using Projeto.Domain;
using Projeto.Infra;

namespace Projeto.Application.Products
{
    public interface IProductsService
    {
        Task<Product[]> FindAllAsync();
        Task SaveChangesAsync();
        Task<Product?> FindByIdAsync(ProductId id);
    }

    [Injectable(typeof(IProductsService))]
    public class ProductsService : IProductsService
    {
        private readonly ProjetoContext Db;

        public ProductsService(ProjetoContext productContext)
        {
            Db = productContext;
        }

        public Task<Product[]> FindAllAsync()
        {
            return Db.Product.ToArrayAsync();
        }
        public Task<Product?> FindByIdAsync(ProductId id)
        {
            return Db.Product.Where(e => e.Id == id).SingleOrDefaultAsync();
        }

        public Task SaveChangesAsync()
          => Db.SaveChangesAsync();
    }
}
