using System.ComponentModel.DataAnnotations;

namespace CouponMarketplace.Application.DTOs;

public class CreateCouponDto
{
    [Required]
    public decimal CostPrice { get; set; }

    [Required]
    public decimal MarginPercentage { get; set; }

    [Required]
    public int ValueType { get; set; }

    [Required]
    public string Value { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    [Required]
    public int Type { get; set; }
}