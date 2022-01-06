using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace iRestaurant.UI.model
{
    public partial class iRestaurantContext : DbContext
    {
        public iRestaurantContext()
        {
        }

        public iRestaurantContext(DbContextOptions<iRestaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FoodCategory> FoodCategories { get; set; }
        public virtual DbSet<FoodIngredient> FoodIngredients { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuIngredient> MenuIngredients { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=database-1.c67n9jn84ktw.us-east-2.rds.amazonaws.com;Database=iRestaurant;Uid=admin;Pwd=caiocaio123!@#;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.ToTable("FoodCategory");

                entity.HasIndex(e => e.RestaurantId, "FK_FoodCategory_Restaurant");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Description).HasMaxLength(20);

                entity.Property(e => e.ModifiedBy).HasColumnType("int(11)");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.RestaurantId).HasColumnType("int(11)");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.FoodCategories)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FoodCategory_Restaurant");
            });

            modelBuilder.Entity<FoodIngredient>(entity =>
            {
                entity.HasIndex(e => e.RestaurantId, "FK_FoodIngredients_Restaurant");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ModifiedBy).HasColumnType("int(11)");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.RestaurantId).HasColumnType("int(11)");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.FoodIngredients)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FoodIngredients_Restaurant");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.HasIndex(e => e.CategoryId, "FK_Menu_FoodCategory");

                entity.HasIndex(e => e.RestaurantId, "FK_Menu_Restaurant");

                entity.Property(e => e.Id).HasColumnType("int(11)");

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
