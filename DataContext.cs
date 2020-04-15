using GuidPoc.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GuidPoc.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlite("Data Source=poc.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().ToTable("customer");

            modelBuilder.Entity<Customer>().HasKey(d => d.Id);

            modelBuilder.Entity<Customer>().HasMany(d => d.Coupons)
                .WithOne(d => d.Customer)
                .HasForeignKey(u => u.CustomerId);

            modelBuilder.Entity<Promotion>().ToTable("promotion");

            modelBuilder.Entity<Promotion>().HasKey(d => d.PromotionId);

            modelBuilder.Entity<Promotion>().HasMany(d => d.Coupons)
                .WithOne()
                .HasForeignKey("PromotionId");

            modelBuilder.Entity<Coupon>().ToTable("coupon");

            modelBuilder.Entity<Coupon>().HasKey(d => d.CouponId);

            modelBuilder.Entity<Coupon>().HasOne(d => d.Customer)
                .WithMany(a => a.Coupons)
                .HasForeignKey(u => u.CustomerId);
        }
    }
}