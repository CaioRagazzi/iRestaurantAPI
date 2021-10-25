using iRestaurant.Domain.Entities;
using iRestaurant.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#nullable disable

namespace iRestaurant.Repository.Context
{
    public partial class RestaurantContext : DbContext
    {
        private IHttpContextAccessor httpContextAccessor;
        public RestaurantContext()
        {
        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            var userId = int.Parse(this.httpContextAccessor?.HttpContext?.User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((AuditableEntity)entityEntry.Entity).CreatedBy = userId;
                }
                else
                {
                    Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                    Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
                }

                ((AuditableEntity)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;
                ((AuditableEntity)entityEntry.Entity).ModifiedBy = userId;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.Deleted).HasColumnType("bit(1)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ModifiedBy).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
