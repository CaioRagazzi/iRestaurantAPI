using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace iRestaurant.UI.Models
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

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

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
