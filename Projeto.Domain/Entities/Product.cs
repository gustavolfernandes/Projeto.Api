namespace Projeto.Domain
{
    public sealed class Product
    {
        /// <summary>
        /// To EF Core
        /// </summary>
        public Product()
        {

        }
        public Product(ProductId id, string name)
        {
            Id = id;
            Name = name;
        }

        public ProductId Id { get; private set; } = default!;
        public string Name { get; private set; } = default!;

        public void Update(string name)
        {
            Name = name;
        }
    }
}
