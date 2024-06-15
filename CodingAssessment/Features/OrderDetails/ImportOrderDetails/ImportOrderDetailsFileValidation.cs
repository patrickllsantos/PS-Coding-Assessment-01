using CodingAssessment.Utilities;
using FluentValidation;

namespace CodingAssessment.Features.OrderDetails.ImportOrderDetails;

/// <summary>
/// Validator for the <see cref="ImportOrderDetailsRequest"/> class.
/// </summary>
public class ImportOrderDetailsFileValidation : AbstractValidator<ImportOrderDetailsRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImportOrderDetailsFileValidation"/> class.
    /// </summary>
    public ImportOrderDetailsFileValidation()
    {
        RuleFor(x => x.File)
            .NotNull()
            .WithMessage("File is required.");
            
        RuleFor(x => x.File)
            .Must(ValidationHelpers.BeAValidCsv)
            .WithMessage("Only CSV files are allowed.");
    }
}
