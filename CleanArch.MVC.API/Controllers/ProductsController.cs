using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.MVC.Application.DTOs;
using CleanArch.MVC.Application.Interfaces;
using CleanArch.MVC.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Products : ControllerBase
    {
        private readonly IProductServices _productServices;
        public Products(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var product = await _productServices.GetProducts();
            if (product == null) return NotFound();

            return Ok(product);
        }
        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int? id)
        {
            if (id == null) return BadRequest("Id cannot be null");

            var product = await _productServices.GetById(id.Value);
            if (product == null) return NotFound("Product not found");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null) return BadRequest();

            await _productServices.Add(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);

        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (productDTO.Id != id) return BadRequest();
            if (productDTO == null) return BadRequest();

            await _productServices.Update(productDTO);

            return Ok(productDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var categoryDTO = await _productServices.GetById(id.Value);
            if (categoryDTO == null) return NotFound();

            await _productServices.Remove(id.Value);

            return Ok();
        }
    }
}