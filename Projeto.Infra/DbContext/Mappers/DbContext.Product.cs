using Microsoft.EntityFrameworkCore;
using Projeto.Domain;

namespace Projeto.Infra
{
    public sealed partial class ProjetoContext : DbContext
    {
        public DbSet<Product> Product { get; set; } = default!;

        private static void MapProducts(ModelBuilder model)
        {
            model.Entity<Product>(map =>
            {
                map.Property(a => a.Id).HasConversion(GetIdConverterFor<ProductId>());
                map.Property(a => a.Name).HasMaxLength(200);
            });
        }

        }
}
