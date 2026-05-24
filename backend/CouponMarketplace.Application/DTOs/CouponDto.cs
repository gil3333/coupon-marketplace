namespace CouponMarketplace.Application.DTOs;

public class CouponDto
{
    public Guid Id { get; set; }

    public decimal CostPrice { get; set; }

    public decimal MarginPercentage { get; set; }

    public bool IsSold { get; set; }

    public int ValueType { get; set; }

    public string Value { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public int Type { get; set; }
}