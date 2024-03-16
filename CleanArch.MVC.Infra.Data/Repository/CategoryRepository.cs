using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using CleanArch.MVC.Domain.Interfaces;
using CleanArch.MVC.Domain.Entities;
using CleanArch.MVC.Domain.Interfaces;
using CleanArch.MVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.MVC.Infra.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            this._categoryContext = context;
        }
        public async Task<Category> Create(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> Remove(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}