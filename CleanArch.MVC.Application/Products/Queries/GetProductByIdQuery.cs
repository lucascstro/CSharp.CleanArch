using CleanArch.MVC.Domain.Entities;
using MediatR;

namespace CleanArch.MVC.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            this.Id = id;
        }
        
    }
}