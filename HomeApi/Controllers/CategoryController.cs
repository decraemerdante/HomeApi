using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.DataAccessLayer.Entity.Models;
using HomeApi.DataAccessLayer.Repositories;
using HomeApi.DataAccessLayer.Repositories.Implementations;
using HomeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        public CategoryController(IShoppingRepository shoppingRepository, ICategoryRepository categoryRepository) : base(shoppingRepository, categoryRepository)
        {
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<ShoppingCategory>> Get(string id)
        {
            var category =  await categoryRepository.Get(id);
            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShoppingCategory>>> Get()
        {
            var categories =  await categoryRepository.Get();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShoppingCategory model)
        {
            
            await categoryRepository.Create(model);
            return Created("", null);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ShoppingCategory model)
        {
            categoryRepository.Update(model, model.Id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
         
            categoryRepository.Delete(id);
            return Ok();
        }
    }
}

