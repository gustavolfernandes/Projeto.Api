namespace Projeto.Domain.Interfaces
{
    public interface IProductsRepository
    {
        void Add(Product entity);
        Task SaveChangesAsync();
        void Remove(Product entity);
    }
}
