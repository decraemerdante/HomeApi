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
    public class ProductController : BaseController
    {
        public ProductController(IShoppingRepository shoppingRepository, ICategoryRepository categoryRepository) : base(shoppingRepository, categoryRepository)
        {
        }
       [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<ShoppingItem>> Get(string id)
        {
            var product =  await shoppingRepository.Get(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShoppingItem>>> Get()
        {
            var products =  await shoppingRepository.Get();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShoppingItem model)
        {
            
            await shoppingRepository.Create(model);
            return Created("", null);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ShoppingItem model)
        {
            shoppingRepository.Update(model, model.Id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
         
            shoppingRepository.Delete(id);
            return Ok();
        }
    }
}

