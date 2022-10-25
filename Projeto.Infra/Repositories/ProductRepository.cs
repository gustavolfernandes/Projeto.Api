using Microsoft.EntityFrameworkCore;
using Projeto.Domain;
using Projeto.Domain.Interfaces;

namespace Projeto.Infra;
[Injectable(typeof(IProductsRepository))]
public sealed class ProductsRepository : IProductsRepository
{
    public ProductsRepository(ProjetoContext context)
    {
        Db = context;
    }

    private ProjetoContext Db { get; }

    public void Add(Product entity)
        => Db.Product.Add(entity);

    public void Remove(Product product) 
        => Db.Product.Remove(product);

    public Task SaveChangesAsync()
        => Db.SaveChangesAsync();
}
