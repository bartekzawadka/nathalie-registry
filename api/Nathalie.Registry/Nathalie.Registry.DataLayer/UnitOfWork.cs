using System;
using Microsoft.EntityFrameworkCore;

namespace Nathalie.Registry.DataLayer
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed;
        private static string _connectionString;
        private readonly NathalieRegistryContext _context = new NathalieRegistryContext(_connectionString);
        public NathalieRegistryContext Context => _context;
        
        public static void Initialize(string connectionString)
        {
            _connectionString = connectionString;
        }

        public GenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }
        
        public void Save()
        {
            _context.SaveChanges();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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