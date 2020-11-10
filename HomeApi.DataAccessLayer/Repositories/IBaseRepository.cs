using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.DataAccessLayer.Repositories.Implementations
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity obj);
        void Update(TEntity obj, string id);
        void Delete(string id);
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> Get();
    }
}
