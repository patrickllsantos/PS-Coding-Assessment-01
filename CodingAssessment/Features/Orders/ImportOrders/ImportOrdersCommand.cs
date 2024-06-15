using MediatR;

namespace CodingAssessment.Features.Orders.Import;

/// <summary>
/// Represents a command to import data from a CSV file.
/// </summary>
/// <param name="OrdersRequest">The import request containing the CSV file.</param>
public record ImportOrdersCommand(ImportOrdersRequest OrdersRequest) : IRequest<Unit>;