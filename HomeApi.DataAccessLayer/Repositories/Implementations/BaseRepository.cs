using HomeApi.DataAccessLayer.Entity;
using HomeApi.DataAccessLayer.Entity.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.DataAccessLayer.Repositories.Implementations
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public readonly IMongoDBContext _mongoContext;
        public IMongoCollection<TEntity> _dbCollection;

        protected BaseRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task Create(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
            await _dbCollection.InsertOneAsync(obj);
        }

        public void Delete(string id)
        {
            //ex. 5dc1039a1521eaa36835e541

            var objectId = new ObjectId(id);
            _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));

        }
        public virtual void Update(TEntity obj, string id)
        {
            var objectId = new ObjectId(id);
            _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId), obj);
        }

        public async Task<TEntity> Get(string id)
        {
            //ex. 5dc1039a1521eaa36835e541

            var objectId = new ObjectId(id);

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);

            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();

        }


        public async Task<IEnumerable<TEntity>> Get()
        {
            var all = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }


    }
}
