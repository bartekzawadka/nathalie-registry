using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Nathalie.Registry.DataLayer.Models;
using Nathalie.Registry.DataLayer.Sys;

namespace Nathalie.Registry.DataLayer
{
    public class GenericRepository<TCollection> where TCollection : DocumentBase
    {
        private IMongoCollection<TCollection> Collection { get; set; }

        public GenericRepository(IMongoCollection<TCollection> collection)
        {
            Collection = collection;
        }

        public virtual async Task<IEnumerable<TCollection>> Get<TFilter>(TFilter filter)
            where TFilter : Filter<TCollection>, new()
        {
            if (filter == null)
            {
                filter = new TFilter();
            }

            if (filter.FilterExpression == null)
            {
                filter.FilterExpression = collection => true;
            }

            var query = Collection.Find(filter.FilterExpression);

            query = query.Skip(filter.PageIndex * filter.PageSize);
            query = query.Limit(filter.PageSize);
            
            if (filter.Sorting?.Count > 0)
            {
                var builder = new SortDefinitionBuilder<TCollection>();
                foreach (var columnSort in filter.Sorting)
                {
                    var stringFieldDefinition = new StringFieldDefinition<TCollection>(columnSort.ColumnName);
                    Func<SortDefinition<TCollection>> sortDefinitionFunc;
                    if (columnSort.IsDescending)
                    {
                        sortDefinitionFunc = () => builder.Descending(stringFieldDefinition);
                    }
                    else
                    {
                        sortDefinitionFunc = () => builder.Ascending(stringFieldDefinition);
                    }

                    query = query.Sort(sortDefinitionFunc());
                }
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TCollection> GetById(string id)
        {
            var query = Collection.Find(f => f.Id == id);
            return await query.SingleOrDefaultAsync();
        }

        public virtual async Task Insert(TCollection document)
        {
            await Collection.InsertOneAsync(document);
        }

        public virtual async Task InsertMany(IEnumerable<TCollection> documents)
        {
            await Collection.InsertManyAsync(documents);
        }

        public virtual async Task Update(string id, TCollection document)
        {
            await Collection.ReplaceOneAsync(f => string.Equals(f.Id, id), document);
        }

        public virtual async Task<bool> Delete(string id)
        {
            var actionResult = await Collection.DeleteOneAsync(f => f.Id == id);
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }
    }
}