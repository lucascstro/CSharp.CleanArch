using CleanArch.MVC.Domain.Entities;
using MediatR;

namespace CleanArch.MVC.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public ProductRemoveCommand(int id)
        {
            this.Id = id;
        }
    }
}