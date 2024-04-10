using CleanArch.MVC.Application.Products.Commands;
using CleanArch.MVC.Domain.Entities;
using CleanArch.MVC.Domain.Interfaces;
using MediatR;

namespace CleanArch.MVC.Application.Products.Handlers
{
    public class ProductRemoveCommamdHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductRemoveCommamdHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id) ?? throw new ApplicationException("Error could not be found");
            var result = await _productRepository.RemoveAsync(product);
            return result;
        }
    }
}