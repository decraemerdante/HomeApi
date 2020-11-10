using HomeApi.DataAccessLayer.Entity;
using HomeApi.DataAccessLayer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.DataAccessLayer.Repositories.Implementations
{
   public  class CategoryRepository : BaseRepository<ShoppingCategory>, ICategoryRepository
    {
        public CategoryRepository(IMongoDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ShoppingCategory>> GetAll()
        {
            var all = await Get();
            return all;
        }
    
    }
}
