using CouponMarketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CouponMarketplace.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Coupon> Coupons => Set<Coupon>();

    public DbSet<User> Users => Set<User>();
}