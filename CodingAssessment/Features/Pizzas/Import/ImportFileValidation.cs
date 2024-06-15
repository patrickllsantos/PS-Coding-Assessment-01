using CodingAssessment.Utilities;
using FluentValidation;

namespace CodingAssessment.Features.Pizzas.Import;

/// <summary>
/// Validator for the <see cref="ImportRequest"/> class.
/// </summary>
public class ImportFileValidation : AbstractValidator<ImportRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImportFileValidation"/> class.
    /// </summary>
    public ImportFileValidation()
    {
        RuleFor(x => x.File)
            .NotNull()
            .WithMessage("File is required.");
            
        RuleFor(x => x.File)
            .Must(ValidationHelpers.BeAValidCsv)
            .WithMessage("Only CSV files are allowed.");
    }
}
