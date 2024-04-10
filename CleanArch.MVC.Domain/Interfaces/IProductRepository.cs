using CleanArch.MVC.Domain.Entities;

namespace CleanArch.MVC.Domain.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> GetProductCategoryAsync(int id);
    Task<Product> CreateAsync (Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> RemoveAsync(Product roduct);
}