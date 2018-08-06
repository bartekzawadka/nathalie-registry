using Microsoft.EntityFrameworkCore;
using Nathalie.Registry.DataLayer.Models;

namespace Nathalie.Registry.DataLayer
{
    public partial class NathalieRegistryContext : DbContext
    {
        public virtual DbSet<Template> Template { get; set; }
        
        public virtual DbSet<TemplateColumn> TemplateColumn { get; set; }
        
        public virtual DbSet<TemplateColumnType> TemplateColumnType { get; set; }
        
        public virtual DbSet<Models.Registry> Registry { get; set; }

        public virtual DbSet<RegistryTemplate> RegistryTemplate { get; set; }

        protected void OnModelCreatingCore(ModelBuilder modelBuilder)
        {
            BuildRegistry(modelBuilder);
            BuildTemplate(modelBuilder);
            BuildTemplateColumn(modelBuilder);
        }

        private void BuildRegistry(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Registry>(entity => { entity.HasMany(e => e.RegistryTemplates); });
        }
        
        private void BuildTemplate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Template>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UX_Template_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasMany(e => e.TemplateColumns);
                entity.HasMany(e => e.RegistryTemplates);
            });
        }

        private void BuildTemplateColumn(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TemplateColumn>(entity => { entity.HasOne(d => d.TemplateColumnType); });
        }
    }
}