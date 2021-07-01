using Catalog.API.Entities;
using Catalog.API.Entities.Base;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext<T> : ICatalogContext<T> where T : EntityBase
    {
        public IMongoCollection<T> Collection { get; }

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Collection = database.GetCollection<T>(configuration["DatabaseSettings:CollectionName"]);
            CatalogContextSeed.Seed(Collection);
        }
    }
}
