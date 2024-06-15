using FluentValidation;

namespace CodingAssessment.Features.OrderDetails.Import;

public class ImportOrderDetailsDataValidation : AbstractValidator<Models.OrderDetails>
{
    public ImportOrderDetailsDataValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("Order id is required.");

        RuleFor(x => x.PizzaId)
            .NotEmpty().WithMessage("Pizza id is required");

        RuleFor(x => x.OrderId)
            .GreaterThanOrEqualTo(0).WithMessage("Invalid order id");

        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Quantity is required.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }
}