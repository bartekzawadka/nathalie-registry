using System;
using System.Linq;
using Nathalie.Registry.DataLayer.Models;
using Nathalie.Registry.DataLayer.Sys.Attributes;

namespace Nathalie.Registry.DataLayer
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed;
        private static string _connectionString;
        private static string _database;
        private NathalieRegistryContext _context = new NathalieRegistryContext(_connectionString, _database);

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
            var collection =  new GenericRepository<T>(_context.Database.GetCollection<T>(
                mongoCollectionAttribute.CollectionName));
            return collection;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Database = null;
                    _context = null;
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