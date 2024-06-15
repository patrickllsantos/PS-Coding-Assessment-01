using CodingAssessment.Utilities;
using FluentValidation;

namespace CodingAssessment.Features.PizzaTypes.ImportPizzaTypes;

/// <summary>
/// Validator for the <see cref="ImportPizzaTypesRequest"/> class.
/// </summary>
public class ImportPizzaTypesValidation : AbstractValidator<ImportPizzaTypesRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImportPizzaTypesValidation"/> class.
    /// </summary>
    public ImportPizzaTypesValidation()
    {
        RuleFor(x => x.File)
            .NotNull()
            .WithMessage("File is required.");
            
        RuleFor(x => x.File)
            .Must(ValidationHelpers.BeAValidCsv)
            .WithMessage("Only CSV files are allowed.");
    }
}
