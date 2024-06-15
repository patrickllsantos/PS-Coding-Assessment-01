using CodingAssessment.Models;
using FluentValidation;

namespace CodingAssessment.Features.Pizzas.ImportPizzas;

public class ImportPizzasDataValidation : AbstractValidator<Pizza>
{
    public ImportPizzasDataValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.PizzaTypeId)
            .NotEmpty().WithMessage("Pizza type is required.");

        RuleFor(x => x.Size)
            .IsInEnum().WithMessage("Size is not a valid value");

        RuleFor(x => x.Price)
            .LessThan(100000);
    }
}