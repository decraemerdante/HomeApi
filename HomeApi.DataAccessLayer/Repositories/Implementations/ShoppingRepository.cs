﻿using HomeApi.DataAccessLayer.Entity;
using HomeApi.DataAccessLayer.Entity.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.DataAccessLayer.Repositories.Implementations
{
   public class ShoppingRepository : BaseRepository<ShoppingItem>, IShoppingRepository
    {
        public ShoppingRepository(IMongoDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ShoppingItem>> GetAll()
        {
            var all = await Get();
            return all;
        }
    }
}
