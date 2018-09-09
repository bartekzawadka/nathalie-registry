using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Nathalie.Registry.DataLayer.Models;
using Nathalie.Registry.DataLayer.Sys.Attributes;

namespace Nathalie.Registry.DataLayer
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed;
        private static string _connectionString;
        private static string _database;
        public NathalieRegistryContext Context = new NathalieRegistryContext(_connectionString, _database);

        public static void Initialize(string connectionString, string database)
        {
            _connectionString = connectionString;
            _database = database;
        }

        public GenericRepository<T> GetRepository<T>() where T : DocumentBase
        {
            var mongoCollectionAttribute = (MongoCollectionAttribute)typeof(T).GetCustomAttributes(
                typeof(MongoCollectionAttribute),
                false)
                .First();
            var collection =  new GenericRepository<T>(Context.Database.GetCollection<T>(
                mongoCollectionAttribute.CollectionName));
            return collection;
        }

        public async Task<IEnumerable<T>> ResolveReferences<T>(string collectionName, IEnumerable<MongoDBRef> reference) where T:DocumentBase
        {
            var query = Context.Database
                .GetCollection<T>(collectionName).AsQueryable();

            var referenceIds = reference.Select(x => x.Id.AsString).ToList();

            query = query.Where(f => referenceIds.Contains(f.Id));

            return await query.ToListAsync();
            
//            var filter = Builders<T>.Filter.Where(t => t.Id == reference.Id.AsString);
//            return await Context.Database
//                .GetCollection<T>(reference.CollectionName)
//                .Find(filter)
//                .FirstOrDefaultAsync();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Database = null;
                    Context = null;
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}