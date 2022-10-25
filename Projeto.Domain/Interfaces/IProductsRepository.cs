namespace Projeto.Domain.Interfaces
{
    public interface IProductsRepository
    {
        Task<Product[]> FindAll();
        Task<Product?> FindById(ProductId id);
        void Add(Product entity);
        Task SaveChanges();
        void Remove(Product entity);
    }
}
