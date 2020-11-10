using HomeApi.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApi.DataAccessLayer.Repositories.Implementations
{
   public class ShoppingRepository : BaseRepository, IShoppingRepository
    {
        public ShoppingRepository(MongoDBContext context) : base(context)
        {
        }
    }
}
