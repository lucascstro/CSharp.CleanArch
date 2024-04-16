using CleanArch.MVC.Application.DTOs;
using CleanArch.MVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanArch.MVC.WebUI.Controllers
{
   
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            this._categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _categoryServices.GetCategories());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryServices.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
         [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null) return NotFound();

            var category = await _categoryServices.GetById(Id.Value);
            if (category == null) return NotFound();

            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryServices.Update(category);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null) return NotFound();

            var category = await _categoryServices.GetById(Id.Value);
            if (category == null) return NotFound();

            return View(category);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null) return NotFound();

            var category = await _categoryServices.GetById(Id.Value);
            if (category == null) return NotFound();

            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? Id)
        {
            if (Id == null) return NotFound();

            await _categoryServices.Remove(Id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}
