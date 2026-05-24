using CouponMarketplace.Application.DTOs;
using CouponMarketplace.Domain.Entities;

namespace CouponMarketplace.Application.Services.Interfaces;

public interface ICouponService
{
    Task<List<Coupon>> GetAllAsync();

    Task<Coupon?> GetByIdAsync(Guid id);

    Task<Coupon> CreateAsync(CreateCouponDto dto);

    Task<Coupon?> UpdateAsync(Guid id, CreateCouponDto dto);

    Task<bool> DeleteAsync(Guid id);
}