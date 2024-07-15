using BasicRestAPI.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BasicRestAPI.Validation
{
    public class ComputerValidation : AbstractValidator<Computer>
    {
        public ComputerValidation()
        {
            RuleFor(x => x.Brand)
                    .NotEmpty()
                    .WithMessage("Enter a Brand name")
                    .MinimumLength(5)
                    .WithMessage("Brand name must be at least 5 characters")
                    .MaximumLength(25)
                    .WithMessage("Brand name must be 25 characters max");

            RuleFor(x => x.Model)
                    .NotEmpty()
                    .WithMessage("Enter a Model name")
                    .MinimumLength(5)
                    .WithMessage("Model name must be at least 5 characters")
                    .MaximumLength(25)
                    .WithMessage("Model name must be 25 characters max");

            RuleFor(x => x.Price)
                    .NotEmpty()
                    .WithMessage("Enter a Price")
                    .GreaterThanOrEqualTo(100)
                    .WithMessage("Price can be at least 100 or more")
                    .LessThanOrEqualTo(10000)
                    .WithMessage("Price can be 10000 or less");
        }
    }
}
