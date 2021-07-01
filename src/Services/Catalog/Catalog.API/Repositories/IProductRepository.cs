using Catalog.API.Entities;
using Catalog.API.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductByName(string name);

        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
    }
}
