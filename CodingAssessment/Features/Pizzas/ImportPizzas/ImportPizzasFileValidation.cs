using CodingAssessment.Utilities;
using FluentValidation;

namespace CodingAssessment.Features.Pizzas.ImportPizzas;

/// <summary>
/// Validator for the <see cref="ImportPizzasRequest"/> class.
/// </summary>
public class ImportPizzasFileValidation : AbstractValidator<ImportPizzasRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImportPizzasFileValidation"/> class.
    /// </summary>
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
