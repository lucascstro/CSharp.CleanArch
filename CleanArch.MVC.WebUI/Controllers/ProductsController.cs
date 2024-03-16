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
   
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            this._productServices = productServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productServices.GetProducts());
        }
    }
}