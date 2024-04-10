using CleanArch.MVC.Application.Products.Queries;
using CleanArch.MVC.Domain.Entities;
using CleanArch.MVC.Domain.Interfaces;
using MediatR;

namespace CleanArch.MVC.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return _productRepository.GetByIdAsync(request.Id);
        }
    }
}