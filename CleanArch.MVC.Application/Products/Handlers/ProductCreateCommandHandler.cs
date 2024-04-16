using CleanArch.MVC.Application.Products.Commands;
using CleanArch.MVC.Domain.Entities;
using CleanArch.MVC.Domain.Interfaces;
using MediatR;

namespace CleanArch.MVC.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image) ?? throw new Exception ($"Error creating entity");

            product.CategoryId = request.CategoryID;
            return await _productRepository.CreateAsync(product);
        }
    }
}