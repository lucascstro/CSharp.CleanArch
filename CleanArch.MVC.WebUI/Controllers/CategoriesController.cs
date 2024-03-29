using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.MVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}