using Catalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(string id);

        Task<Product> GetProductByName(string name);

        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);

        
        Task CreateProduct(Product product);
        
        Task UpdateProduct(Product product);
        
        Task DeleteProduct(string id);



    }
}
