using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CleanArch.MVC.Application.DTOs;
using CleanArch.MVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using ZstdSharp.Unsafe;

namespace CleanArch.MVC.WebUI.Controllers
{

    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ProductsController(IProductServices productServices, ICategoryServices categoryServices)
        {
            this._productServices = productServices;
            this._categoryServices = categoryServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productServices.GetProducts());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryServices.GetCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productServices.Add(product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryId = new SelectList(await _categoryServices.GetCategories(), "Id", "Name");
            return View(product);
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id.Value == null) return NotFound();
            var produto = await _productServices.GetById(id.Value);
            if (produto == null) return NotFound();
            ViewBag.CategoryId = new SelectList(await _categoryServices.GetCategories(), "Id", "Name");

            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO product)
        {
            ViewBag.CategoryId = new SelectList(await _categoryServices.GetCategories(), "Id", "Name");

            if (ModelState.IsValid)
            {
                await _productServices.Update(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id.Value == null) return NotFound();

            var produto = await _productServices.GetById(id.Value);

            if (produto == null) return NotFound();
            return View(produto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id.Value == null) return NotFound();

            var produto = await _productServices.GetById(id.Value);

            if (produto == null) return NotFound();
            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? Id)
        {
            if (Id == null) return NotFound();

            await _productServices.Remove(Id.Value);
            return RedirectToAction(nameof(Index));
        }
    }
}