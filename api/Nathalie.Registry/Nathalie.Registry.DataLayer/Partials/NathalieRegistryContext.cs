using Microsoft.EntityFrameworkCore;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.DataLayer
{
    public partial class NathalieRegistryContext : DbContext
    {
        public virtual DbSet<Template> Template { get; set; }

        protected void OnModelCreatingCore(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Template>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UX_Template_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            });
        }
    }
}