using CleanArch.MVC.Domain.Entities;

namespace CleanArch.MVC.Domain.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetByIdAsync(int? id);
    Task<Product> GetProductCategoryAsync(int? id);
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task<Product> Remove(Product roduct);
}