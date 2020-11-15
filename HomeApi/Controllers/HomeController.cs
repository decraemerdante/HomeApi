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
    public class HomeController : BaseController
    {
        public HomeController(IShoppingRepository shoppingRepository, ICategoryRepository categoryRepository) : base(shoppingRepository, categoryRepository)
        {
        }

        [HttpGet]
        public async Task<ActionResult<ShoppingList>> Index()
        {
            var categories = await categoryRepository.Get();
            var products = await shoppingRepository.Get();

            ShoppingList model = new ShoppingList(categories, products);

            return Ok(model);
        }
    }
}