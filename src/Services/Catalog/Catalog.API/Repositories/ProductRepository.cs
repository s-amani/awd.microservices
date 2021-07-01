using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ICatalogContext<Product> context) : base(context)
        {
        }

        public async Task<Product> GetProductByName(string name)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Name, name);

            return await Context
                            .Collection
                            .Find(filter)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Category, categoryName);

            return await Context
                            .Collection
                            .Find(filter)
                            .ToListAsync();
        }
    }
}
