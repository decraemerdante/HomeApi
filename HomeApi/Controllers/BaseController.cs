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
    public class BaseController : ControllerBase
    {
         public IShoppingRepository shoppingRepository;
        public ICategoryRepository categoryRepository;
        public BaseController(IShoppingRepository shoppingRepository, ICategoryRepository categoryRepository)
        {
            this.shoppingRepository = shoppingRepository;
            this.categoryRepository = categoryRepository;
        }
    }
}