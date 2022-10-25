namespace Projeto.Domain.Interfaces
{
    public interface IProductsRepository
    {
        Task<Product[]> FindAllAsync();
        Task<Product?> FindByIdAsync(ProductId id);
        void Add(Product entity);
        Task SaveChangesAsync();
        void Remove(Product entity);
    }
}
