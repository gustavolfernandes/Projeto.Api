using Projeto.Domain.Interfaces;
using Projeto.Infra;
using Projeto.Domain;
using Projeto.Application.Products.Services;

namespace Projeto.Application.Products
{
    [Injectable(LifeTime.Scoped)]
    public sealed class ProductsCommandHandler :
        ICommandHandler<PostProductCommand>,
        ICommandHandler<DeleteProductCommand>,
        ICommandHandler<PutProductCommand>
    {
        public ProductsCommandHandler(IProductsRepository productsRepository, IProductsService productsService)
        {
            ProductsRepository = productsRepository;
            ProductsService = productsService;
        }

        private IProductsRepository ProductsRepository { get; }
        private IProductsService ProductsService { get; }

        public async Task RunAsync(PostProductCommand command)
        {
            var (id, name) = command;
            ProductsRepository.Add(new Product(id, name));
            await ProductsRepository.SaveChangesAsync();
        }

        public async Task RunAsync(DeleteProductCommand command)
        {
            var id = command.Id.ToType<ProductId>();

            var entity = await ProductsService.FindByIdAsync(id);
            if (entity is null) throw new AppException("Product not found");

            ProductsRepository.Remove(entity);
            await ProductsRepository.SaveChangesAsync();
        }

        public async Task RunAsync(PutProductCommand command)
        {
            var (id, name) = command;

            var entity = await ProductsService.FindByIdAsync(id);
            if (entity is null) throw new AppException("Product not found");

            entity.Update(name);
            await ProductsRepository.SaveChangesAsync();
        }
    }
}
