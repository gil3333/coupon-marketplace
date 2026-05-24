using CouponMarketplace.Application.DTOs;
using FluentValidation;

namespace CouponMarketplace.Application.Validators;

public class CreateCouponDtoValidator : AbstractValidator<CreateCouponDto>
{
    public CreateCouponDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.CostPrice)
            .GreaterThan(0);

        RuleFor(x => x.MarginPercentage)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Value)
            .NotEmpty();

        RuleFor(x => x.ImageUrl)
            .NotEmpty()
            .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            .WithMessage("ImageUrl must be a valid URL");
    }
}