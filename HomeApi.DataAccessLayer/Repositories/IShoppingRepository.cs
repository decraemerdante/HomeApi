﻿using HomeApi.DataAccessLayer.Entity.Models;
using HomeApi.DataAccessLayer.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.DataAccessLayer.Repositories
{
   public interface IShoppingRepository: IBaseRepository<ShoppingItem>
    {
        Task<IEnumerable<ShoppingItem>> GetAll();
    }
}
