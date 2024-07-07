using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class CouponDbContext : DbContext
    {
        public CouponDbContext(DbContextOptions<CouponDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        // Seeding Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon { CouponId = 1, CouponCode = "10OFF", DiscountAmount = 10, MinAmount = 20 });
            modelBuilder.Entity<Coupon>().HasData(new Coupon { CouponId = 2, CouponCode = "20OFF", DiscountAmount = 20, MinAmount = 40 });
        }
    }
}
