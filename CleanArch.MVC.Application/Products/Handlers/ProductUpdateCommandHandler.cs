using CleanArch.MVC.Application.Products.Commands;
using CleanArch.MVC.Domain.Entities;
using CleanArch.MVC.Domain.Interfaces;
using MediatR;

namespace CleanArch.MVC.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler:IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id) ?? throw new ApplicationException($"Error could not be found");
            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryID);
            return await _productRepository.UpdateAsync(product);
        }
    }
}