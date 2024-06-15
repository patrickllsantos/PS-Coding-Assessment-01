using CodingAssessment.Utilities;
using FluentValidation;

namespace CodingAssessment.Features.Orders.Import;

/// <summary>
/// Validator for the <see cref="ImportOrdersRequest"/> class.
/// </summary>
public class ImportOrdersFileValidation : AbstractValidator<ImportOrdersRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImportOrdersFileValidation"/> class.
    /// </summary>
    public ImportOrdersFileValidation()
    {
        RuleFor(x => x.File)
            .NotNull()
            .WithMessage("File is required.");
            
        RuleFor(x => x.File)
            .Must(ValidationHelpers.BeAValidCsv)
            .WithMessage("Only CSV files are allowed.");
    }
}
