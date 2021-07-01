using Catalog.API.Entities.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalog.API.Repositories.Base
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression = null);
        //Task<IEnumerable<T>> GetAll(FilterDefinition<T> filter = null);

        Task<T> GetOne(Expression<Func<T, bool>> expression = null);
        //Task<T> GetOne(FilterDefinition<T> filter = null);


        Task Insert(T model);

        Task<bool> Update(T model);

        Task<bool> Delete(string id);
    }
}
