using MediatR;

namespace CodingAssessment.Features.PizzaTypes.Import;

/// <summary>
/// Represents a command to import data from a CSV file.
/// </summary>
/// <param name="PizzaTypesRequest">The import request containing the CSV file.</param>
public record ImportPizzaTypesCommand(ImportPizzaTypesRequest PizzaTypesRequest) : IRequest<Unit>;