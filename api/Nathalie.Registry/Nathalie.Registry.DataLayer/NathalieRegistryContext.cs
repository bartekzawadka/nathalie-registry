using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Nathalie.Registry.DataLayer
{
    public partial class NathalieRegistryContext : DbContext
    {
        private readonly string _connectionString;
        
        public NathalieRegistryContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingCore(modelBuilder);

            foreach (var fk in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var pp in fk.GetProperties())
                {
                    if (pp.IsForeignKey())
                    {
                        foreach (var ppp in pp.GetContainingForeignKeys())
                        {
                            ppp.DeleteBehavior = DeleteBehavior.Cascade;
                        }
                    }
                }
            }
        }
    }
}