using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.MVC.Application.DTOs;
using CleanArch.MVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Categories : ControllerBase
    {
        private ICategoryServices _categoryServices;
        public Categories(ICategoryServices categoryServices)
        {
            this._categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryServices.GetCategories();
            if (categories == null) return NotFound("Categories not found");
             
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get(int id)
        {
            var categories = await _categoryServices.GetById(id);
            if (categories == null)
                return NotFound("Categories not found");
            else
                return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return BadRequest();

            await _categoryServices.Add(categoryDTO);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO.Id != id) return BadRequest();
            if (categoryDTO == null) return BadRequest();

            await _categoryServices.Update(categoryDTO);

            return Ok(categoryDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var categoryDTO = await _categoryServices.GetById(id.Value);
            if (categoryDTO == null) return NotFound();

            await _categoryServices.Remove(id.Value);

            return Ok();
        }
    }


}