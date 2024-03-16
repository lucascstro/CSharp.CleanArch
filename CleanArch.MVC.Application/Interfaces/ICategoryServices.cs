using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.MVC.Application.DTOs;

namespace CleanArch.MVC.Application.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int id);
        Task Add(CategoryDTO category);
        Task Update(CategoryDTO category);
        Task Remove(int id);
    }
}