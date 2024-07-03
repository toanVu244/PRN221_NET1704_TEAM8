using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Entities
{
    public class JPOSDbContext : DbContext
    {
        public JPOSDbContext(DbContextOptions<JPOSDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Design> Designs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public string GetNextUserId()
        {
            var lastUserId = Users
                .OrderByDescending(u => u.UserID)
                .FirstOrDefault()?.UserID;

            if (lastUserId == null)
            {
                return "US00001";
            }

            var numberPart = int.Parse(lastUserId.Substring(2));
            var nextNumberPart = (numberPart + 1).ToString("D5");

            return $"US{nextNumberPart}";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.UserID).IsRequired();
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Email);
                entity.Property(e => e.FullName);
                entity.Property(e => e.PhoneNum);
                entity.Property(e => e.Address);
                entity.Property(e => e.CreateDate);
                entity.Property(e => e.Status);
                entity.HasOne(e => e.Role)
                      .WithMany()
                      .HasForeignKey(e => e.RoleID);
            });

            // Configure Role entity
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleID);
                entity.Property(e => e.RoleName);
            });

            // Configure Blog entity
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasKey(e => e.BlogID);
                entity.Property(e => e.Title);
                entity.Property(e => e.Content);
                entity.Property(e => e.CreateDate);
                entity.Property(e => e.CreateBy);
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.CreateBy);
            });

            // Configure Request entity
            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Description);
                entity.Property(e => e.CreateDate);
                entity.Property(e => e.Status);
                entity.Property(e => e.Image);
                entity.Property(e => e.Type);
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserID);

                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductID);
            });

            // Configure Design entity
            modelBuilder.Entity<Design>(entity =>
            {
                entity.HasKey(e => e.DesignID);
                entity.Property(e => e.CreateBy);
                entity.Property(e => e.Picture);
                entity.Property(e => e.Description);
                entity.Property(e => e.CreateDate);
            });

            // Configure Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductID);
                entity.Property(e => e.ProductName);
                entity.Property(e => e.Image);
                entity.Property(e => e.PriceMaterial);
                entity.Property(e => e.PriceDesign);
                entity.Property(e => e.ProcessPrice);
                entity.Property(e => e.CategoryID);
                entity.Property(e => e.DesignID);
                entity.Property(e => e.Status);
                entity.Property(e => e.CreateBy);
                entity.Property(e => e.CreateDate);
                entity.Property(e => e.Description);

                entity.HasMany(e => e.Requests)
                      .WithOne(e => e.Product)
                      .HasForeignKey(e => e.ProductID);
            });

            // Configure Category entity
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatID);
                entity.Property(e => e.CatName);
                entity.Property(e => e.Description);
            });

            // Configure ProductMaterial entity
            modelBuilder.Entity<ProductMaterial>(entity =>
            {
                entity.HasKey(e => e.ProductMaterialID);
                entity.Property(e => e.Quantity);
                entity.Property(e => e.Price);
                entity.HasOne(e => e.Product)
                      .WithMany(e => e.ProductMaterial)
                      .HasForeignKey(e => e.ProductID);
                entity.HasOne(e => e.Material)
                      .WithMany(e => e.ProductMaterial)
                      .HasForeignKey(e => e.MaterialID);
            });

            // Configure Material entity
            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.MaterialID);
                entity.Property(e => e.Name);
                entity.Property(e => e.Price);
                entity.Property(e => e.Quantity);
                entity.Property(e => e.TotalPrice);
                entity.Property(e => e.Status);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                // Primary key
                entity.HasKey(f => f.FeedBackID);
                entity.Property(e => e.Content);
                entity.Property(e => e.Rate);
                entity.Property(e => e.UserID);
                entity.Property(e => e.ProductID);
                // Foreign key relationship to User
                entity.HasOne(f => f.User)
                      .WithMany()
                      .HasForeignKey(f => f.UserID);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                // Primary key
                entity.HasKey(p => p.PolicyID);
                entity.Property(e => e.Title);
                entity.Property(e => e.Content);
                entity.Property(e => e.CreateBy);
                entity.Property(e => e.CreateDate);
                entity.HasOne(f => f.User)
                      .WithMany()
                      .HasForeignKey(f => f.CreateBy);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                // Primary key
                entity.HasKey(p => p.TransactionID);
                entity.Property(e => e.RequestID);
                entity.Property(e => e.Description);
                entity.Property(e => e.CreatedDate);
                entity.HasOne(f => f.User)
                      .WithMany()
                      .HasForeignKey(f => f.UserID);
            });

        }
    }
}
