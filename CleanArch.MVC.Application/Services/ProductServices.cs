using AutoMapper;
using CleanArch.MVC.Application.DTOs;
using CleanArch.MVC.Application.Interfaces;
using CleanArch.MVC.Domain.Entities;
using CleanArch.MVC.Domain.Interfaces;

namespace CleanArch.MVC.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductServices(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;

        }
        public async Task<ProductDTO> GetById(int id)
        {
            return mapper.Map<ProductDTO>(await productRepository.GetByIdAsync(id));
        }

        public async Task<ProductDTO> GetProductCategory(int id)
        {
            return mapper.Map<ProductDTO>(await productRepository.GetProductCategoryAsync(id));
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return mapper.Map<IEnumerable<ProductDTO>>(await productRepository.GetProductsAsync());
        }
        public async Task Add(ProductDTO productDTO)
        {
            await productRepository.Create(mapper.Map<Product>(productDTO));
        }

        public async Task Update(ProductDTO productDTO)
        {
            await productRepository.Update(mapper.Map<Product>(productDTO));
        }

        public async Task Remove(int id)
        {
            var product = productRepository.GetByIdAsync(id).Result;
            await productRepository.Remove(product);
        }
    }
}