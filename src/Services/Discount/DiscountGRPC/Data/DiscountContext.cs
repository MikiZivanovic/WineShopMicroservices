using DiscountGRPC.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscountGRPC.Data
{
    public class DiscountContext :DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options) 
        {
            
        }

        public DbSet<Coupon> Coupons { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                    new Coupon() { Id = 1, ProductName="Tamjanika Delight",Description="Tamjanika Discount",Amount=150 },
                    new Coupon() { Id = 2, ProductName = "Pinot Noir Elegance", Description = "Pinot Noir Eleganc Discount", Amount = 100 }
                );
        }
    }
}
