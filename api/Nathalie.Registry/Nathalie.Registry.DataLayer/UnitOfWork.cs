using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
        public static string Database { get; private set; }
        public NathalieRegistryContext Context = new NathalieRegistryContext(_connectionString, Database);

        public static void Initialize(string connectionString, string database)
        {
            _connectionString = connectionString;
            Database = database;
        }

        public GenericRepository<T> GetRepository<T>() where T : DocumentBase
        {
            var mongoCollectionAttribute = (MongoCollectionAttribute)typeof(T).GetCustomAttributes(
                typeof(MongoCollectionAttribute),
                false)
                .First();
            
            return new GenericRepository<T>(Context.Database.GetCollection<T>(mongoCollectionAttribute.CollectionName));
        }

        public async Task<IEnumerable<T>> ResolveReferences<T>(IEnumerable<string> reference) where T:DocumentBase
        {
            var attribute = (MongoCollectionAttribute) typeof(T)
                .GetCustomAttribute(typeof(MongoCollectionAttribute));

            var collection = Context.Database.GetCollection<T>(attribute.CollectionName);
            var query = collection.AsQueryable();

            var referenceIds = reference.ToList(); 
            
            query = query.Where(f => referenceIds.Contains(f.Id));

            return await query.ToListAsync();
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