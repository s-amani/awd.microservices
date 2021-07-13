using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("{UserName} is required")
                .NotNull()
                .MaximumLength(50)
                .WithMessage("{UserName} must be not exceed 50 character");

            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("{EmailAddress} is required");
            
            RuleFor(x => x.TotalPrice)
                .NotEmpty()
                .WithMessage("{TotalPrice} is required")
                .GreaterThan(0)
                .WithMessage("{TotalPrice} should be greater that zero");
        }
    }
}
