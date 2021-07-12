using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Entities.Base;
using Catalog.API.Repositories.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly ICatalogContext<T> Context;

        public GenericRepository(ICatalogContext<T> context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression = null) =>
                        await Context
                            .Collection
                            .Find(expression == null ? x => true : expression)
                            .ToListAsync();

        public async Task<IEnumerable<T>> GetAll(FilterDefinition<T> filter = null) =>
                        await Context
                            .Collection
                            .Find(filter)
                            .ToListAsync();

        public async Task<T> GetOne(Expression<Func<T, bool>> expression = null) =>
                        await Context
                            .Collection
                            .Find(expression == null ? x => true : expression)
                            .FirstOrDefaultAsync();

        public async Task<T> GetOne(FilterDefinition<T> filter = null) =>
                        await Context
                            .Collection
                            .Find(filter)
                            .FirstOrDefaultAsync();

        public async Task Insert(T model) => await Context.Collection.InsertOneAsync(model);

        public async Task<bool> Update(T model)
        {
            var result = await Context
                                .Collection
                                .ReplaceOneAsync(filter: x => x.Id == model.Id, replacement: model);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);

            var result = await Context
                                .Collection
                                .DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

    }
}
