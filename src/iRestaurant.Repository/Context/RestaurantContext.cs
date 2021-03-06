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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RestaurantContext(DbContextOptions<RestaurantContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            var userInToken = _httpContextAccessor?.HttpContext?.User?.Claims?.Where(c => c.Type == "UserId")?.FirstOrDefault()?.Value;

            var userId = userInToken == null ? 0 : int.Parse(userInToken);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((AuditableEntity)entityEntry.Entity).CreatedBy = userId;
                    ((AuditableEntity)entityEntry.Entity).Deleted = false;
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

        public virtual DbSet<FoodCategory> FoodCategories { get; set; }
        public virtual DbSet<FoodIngredient> FoodIngredients { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderMenu> OrderMenus { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuIngredient> MenuIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.ToTable("FoodCategory");

                entity.HasIndex(e => e.RestaurantId, "FK_FoodCategory_Restaurant");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.Description).HasMaxLength(20);

                entity.Property(e => e.ModifiedBy).HasColumnType("int(11)");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.RestaurantId).HasColumnType("int(11)");

                entity.HasQueryFilter(p => !p.Deleted);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.FoodCategories)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FoodCategory_Restaurant");
            });

            modelBuilder.Entity<FoodIngredient>(entity =>
            {
                entity.HasIndex(e => e.RestaurantId, "FK_FoodIngredients_Restaurant");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Description).HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasColumnType("int(11)");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.RestaurantId).HasColumnType("int(11)");

                entity.HasQueryFilter(p => !p.Deleted);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.FoodIngredients)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FoodIngredients_Restaurant");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.RestaurantId, "FK_Order_Restaurant");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Description).HasMaxLength(20);

                entity.Property(e => e.ModifiedBy).HasColumnType("int(11)");

                entity.Property(e => e.RestaurantId).HasColumnType("int(11)");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Restaurant");
            });

            modelBuilder.Entity<OrderMenu>(entity =>
            {
                entity.ToTable("OrderMenu");

                entity.HasIndex(e => e.MenuId, "FK_OrderMenu_Menu");

                entity.HasIndex(e => e.OrderId, "FK_OrderMenu_Order");

                entity.HasIndex(e => e.RestaurantId, "FK_OrderMenu_Restaurant");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AdditionalComment).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.MenuId).HasColumnType("int(11)");

                entity.Property(e => e.ModifiedBy).HasColumnType("int(11)");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.RestaurantId).HasColumnType("int(11)");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.OrderMenus)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderMenu_Menu");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderMenus)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderMenu_Order");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.OrderMenus)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderMenu_Restaurant");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.HasIndex(e => e.CategoryId, "FK_Menu_FoodCategory");

                entity.HasIndex(e => e.RestaurantId, "FK_Menu_Restaurant");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Description).HasMaxLength(20);

                entity.Property(e => e.ModifiedBy).HasColumnType("int(11)");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.RestaurantId).HasColumnType("int(11)");

                entity.HasQueryFilter(p => !p.Deleted);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_FoodCategory");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_Restaurant");
            });

            modelBuilder.Entity<MenuIngredient>(entity =>
            {
                entity.ToTable("MenuIngredient");

                entity.HasIndex(e => e.IngredientId, "FK_MenuIngredient_FoodIngredients");

                entity.HasIndex(e => e.MenuId, "FK_MenuIngredient_Menu");

                entity.HasIndex(e => e.RestaurantId, "FK_MenuIngredient_Restaurant");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IngredientId).HasColumnType("int(11)");

                entity.Property(e => e.MenuId).HasColumnType("int(11)");

                entity.Property(e => e.ModifiedBy).HasColumnType("int(11)");

                entity.Property(e => e.RestaurantId).HasColumnType("int(11)");

                entity.HasQueryFilter(p => !p.Deleted);

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.MenuIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuIngredient_FoodIngredients");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuIngredients)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuIngredient_Menu");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.MenuIngredients)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuIngredient_Restaurant");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.Deleted).HasColumnType("bit(1)");

                entity.Property(e => e.ModifiedBy).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.RestaurantId, "Users_FK");

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

                entity.Property(e => e.RestaurantId).HasColumnType("int(11)");

                entity.Property(e => e.TypeAuth).HasColumnType("int(11)");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
