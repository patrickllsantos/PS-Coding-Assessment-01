﻿using CodingAssessment.Features.Shared.Import;
using MediatR;

namespace CodingAssessment.Features.Orders.Import;

/// <summary>
/// Represents a command to import data from a CSV file.
/// </summary>
/// <param name="Request">The import request containing the CSV file.</param>
public record ImportCommand(ImportRequest Request) : IRequest<Unit>;