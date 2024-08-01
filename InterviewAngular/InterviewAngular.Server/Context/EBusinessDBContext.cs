﻿using InterviewAngular.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewAngular.Server.Context
{
    public class EBusinessDBContext  : DbContext
    {
        public EBusinessDBContext(DbContextOptions<EBusinessDBContext> options): base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Many to Many relationship between User and Role
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
            //One to Many relationship between Product and others

            modelBuilder.Entity<Product>(entity => {
                entity.HasMany<OrderDetail>(e => e.OrderDetails)
                  .WithOne(od => od.Product)
                  .HasForeignKey(od => od.ProductId);

                entity.HasMany<CartItem>(e => e.CartItems)
                      .WithOne(ci => ci.Product)
                      .HasForeignKey(ci => ci.ProductId);

                entity.HasOne<ProductBrand>(e => e.ProductBrand)
                      .WithMany(b => b.Products)
                      .HasForeignKey(e => e.ProductBrandId);
                //entity.HasKey(pc => new { pc.Categories });
                entity.HasMany(e => e.Categories)
                      .WithMany(c => c.Products);
            });


            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderDate).IsRequired();
                entity.HasIndex(e => e.OrderNumber).IsUnique();
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Orders)
                      .HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.OrderDetails)
                      .WithOne(od => od.Order)
                      .HasForeignKey(od => od.OrderId);
               
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Product)
                      .WithMany(p => p.OrderDetails)
                      .HasForeignKey(e => e.ProductId);

                entity.HasOne(e => e.Order)
                      .WithMany(o => o.OrderDetails)
                      .HasForeignKey(e => e.OrderId);
            });

            //Handle Decimal avoid precision loss

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.CostPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Discount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Product> Products { get; set; }
        public  DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<ProductImage> Images { get; set; }
        public DbSet<ProductSpecification> Specifications { get; set; }

    }
}