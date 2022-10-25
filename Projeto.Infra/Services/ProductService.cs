using Microsoft.EntityFrameworkCore;
using Projeto.Application.Products.Services;
using Projeto.Domain;
using Projeto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Services
{
    [Injectable(typeof(IProductsService))]
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository ProductsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            ProductsRepository = productsRepository;
        }

        public Task<Product[]> FindAll() 
            => ProductsRepository.FindAll();
        public Task<Product?> FindById(ProductId id) 
            => ProductsRepository.FindById(id);
    }
}
