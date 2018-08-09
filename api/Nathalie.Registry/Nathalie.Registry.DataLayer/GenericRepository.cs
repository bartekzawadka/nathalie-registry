using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.DataLayer
{
    public class GenericRepository<TCollection> where TCollection : DocumentBase
    {
        private IMongoCollection<TCollection> Collection { get; set; }

        public GenericRepository(IMongoCollection<TCollection> collection)
        {
            Collection = collection;
        }

        public virtual async Task<IEnumerable<TCollection>> Get(Expression<Func<TCollection, bool>> filter = null)
        {
            if (filter == null)
            {
                filter = f => true;
            }

            var query = Collection.Find(filter);
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