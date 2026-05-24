using CouponMarketplace.Domain.Enums;

namespace CouponMarketplace.Domain.Entities;

public class Coupon : Product
{
    public decimal CostPrice { get; set; }

    public decimal MarginPercentage { get; set; }

    public bool IsSold { get; set; } = false;

    public CouponValueType ValueType { get; set; }

    public string Value { get; set; } = string.Empty;

    public decimal MinimumSellPrice =>
        CostPrice * (1 + MarginPercentage / 100);
}