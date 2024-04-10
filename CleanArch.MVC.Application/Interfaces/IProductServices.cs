using CleanArch.MVC.Application.DTOs;

namespace CleanArch.MVC.Application.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int id);
        Task<ProductDTO> GetProductCategory(int id);
        Task Add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Remove(int id);
    }
}