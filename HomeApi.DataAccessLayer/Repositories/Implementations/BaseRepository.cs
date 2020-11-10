using HomeApi.DataAccessLayer.Entity;
using HomeApi.DataAccessLayer.Entity.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApi.DataAccessLayer.Repositories.Implementations
{
    public class BaseRepository: IBaseRepository
    {
        public readonly MongoDBContext _mongoContext;
        public IMongoCollection<ShoppingItem> _dbCollection;

        protected BaseRepository(MongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<ShoppingItem>(typeof(ShoppingItem).Name);
        }
    }
}
