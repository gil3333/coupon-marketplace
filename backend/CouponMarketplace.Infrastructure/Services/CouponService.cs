using CouponMarketplace.Application.DTOs;
using CouponMarketplace.Application.Services.Interfaces;
using CouponMarketplace.Domain.Entities;
using CouponMarketplace.Domain.Enums;
using CouponMarketplace.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CouponMarketplace.Infrastructure.Services;
public class CouponService : ICouponService
{
    private readonly AppDbContext _context;

    public CouponService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Coupon>> GetAllAsync()
    {
        return await _context.Coupons.ToListAsync();
    }

    public async Task<Coupon?> GetByIdAsync(Guid id)
    {
        return await _context.Coupons.FindAsync(id);
    }

    public async Task<Coupon> CreateAsync(CreateCouponDto dto)
    {
        var coupon = new Coupon
        {
            Id = Guid.NewGuid(),
            CostPrice = dto.CostPrice,
            MarginPercentage = dto.MarginPercentage,
            ValueType = (CouponValueType)dto.ValueType,
            Value = dto.Value,
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Type = (ProductType)dto.Type,
            IsSold = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Coupons.Add(coupon);

        await _context.SaveChangesAsync();

        return coupon;
    }

    public async Task<Coupon?> UpdateAsync(Guid id, CreateCouponDto dto)
    {
        var coupon = await _context.Coupons.FindAsync(id);

        if (coupon == null)
            return null;

        coupon.CostPrice = dto.CostPrice;
        coupon.MarginPercentage = dto.MarginPercentage;
        coupon.ValueType = (CouponValueType)dto.ValueType;
        coupon.Value = dto.Value;
        coupon.Name = dto.Name;
        coupon.Description = dto.Description;
        coupon.ImageUrl = dto.ImageUrl;
        coupon.Type = (ProductType)dto.Type;
        coupon.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return coupon;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var coupon = await _context.Coupons.FindAsync(id);

        if (coupon == null)
            return false;

        _context.Coupons.Remove(coupon);

        await _context.SaveChangesAsync();

        return true;
    }
}