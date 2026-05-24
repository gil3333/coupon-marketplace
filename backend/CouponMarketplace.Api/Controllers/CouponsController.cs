using CouponMarketplace.Application.DTOs;
using CouponMarketplace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CouponMarketplace.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouponsController : ControllerBase
{
    private readonly ICouponService _couponService;

    public CouponsController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCoupons()
    {
        var coupons = await _couponService.GetAllAsync();

        return Ok(coupons);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCoupon(Guid id)
    {
        var coupon = await _couponService.GetByIdAsync(id);

        if (coupon == null)
            return NotFound();

        return Ok(coupon);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoupon(CreateCouponDto dto)
    {
        var coupon = await _couponService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetCoupon), new { id = coupon.Id }, coupon);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCoupon(Guid id, CreateCouponDto dto)
    {
        var coupon = await _couponService.UpdateAsync(id, dto);

        if (coupon == null)
            return NotFound();

        return Ok(coupon);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoupon(Guid id)
    {
        var deleted = await _couponService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}