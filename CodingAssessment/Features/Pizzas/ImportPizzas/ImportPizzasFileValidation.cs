using CodingAssessment.Utilities;
using FluentValidation;

namespace CodingAssessment.Features.Pizzas.ImportPizzas;

/// <summary>
/// Validator for the <see cref="ImportPizzasRequest"/> class.
/// </summary>
public class ImportPizzasFileValidation : AbstractValidator<ImportPizzasRequest>
{
    public ImportPizzasFileValidation()
    {
        RuleFor(x => x.File)
            .NotNull()
            .WithMessage("File is required.");
            
        RuleFor(x => x.File)
            .Must(ValidationHelpers.BeAValidCsv)
            .WithMessage("Only CSV files are allowed.");
    }
}
