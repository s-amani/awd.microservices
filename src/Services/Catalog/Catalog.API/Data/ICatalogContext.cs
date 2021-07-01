using Catalog.API.Entities;
using Catalog.API.Entities.Base;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public interface ICatalogContext<T> where T : EntityBase
    {
        IMongoCollection<T> Collection { get; }        
    }
}
