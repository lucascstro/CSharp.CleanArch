using CleanArch.MVC.Domain.Entities;
using MediatR;

namespace CleanArch.MVC.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        
    }
}