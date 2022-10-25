using Projeto.Domain.Interfaces;
using Projeto.Infra;
using Projeto.Domain;
using Projeto.Application.Products.Services;
using MediatR;

namespace Projeto.Application.Products
{
    [Injectable(LifeTime.Scoped)]
    public sealed class ProductsCommandHandler :
        IRequestHandler<PostProductCommand, ProductCommandResponse>,
        IRequestHandler<DeleteProductCommand, ProductCommandResponse>,
        IRequestHandler<PutProductCommand, ProductCommandResponse>
    {
        public ProductsCommandHandler(IProductsRepository productsRepository, IProductsService productsService)
        {
            ProductsRepository = productsRepository;
            ProductsService = productsService;
        }

        private IProductsRepository ProductsRepository { get; }
        private IProductsService ProductsService { get; }

        public async Task<ProductCommandResponse> Handle(PostProductCommand command, CancellationToken cancellationToken)
        {
            var (id, name) = command;
            ProductsRepository.Add(new Product(id, name));
            await ProductsRepository.SaveChanges();
            var response = new ProductCommandResponse(true);
            return response;
        }

        public async Task<ProductCommandResponse> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var id = command.Id.ToType<ProductId>();

            var entity = await ProductsService.FindById(id);
            if (entity is null) throw new AppException("Product not found");

            ProductsRepository.Remove(entity);
            await ProductsRepository.SaveChanges();
            var response = new ProductCommandResponse(true);
            return response;
        }

        public async Task<ProductCommandResponse> Handle(PutProductCommand command, CancellationToken cancellationToken)
        {
            var (id, name) = command;

            var entity = await ProductsService.FindById(id);
            if (entity is null) throw new AppException("Product not found");

            entity.Update(name);
            await ProductsRepository.SaveChanges();
            var response = new ProductCommandResponse(true);
            return response;
        }
    }
}
