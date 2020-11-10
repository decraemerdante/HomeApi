using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApi.DataAccessLayer.Entity
{
   public interface IMongoDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
