using CodingAssessment.Features.OrderDetails.GetOrderDetails;
using CodingAssessment.Features.OrderDetails.ImportOrderDetails;
using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.OrderDetails;

/// <summary>
/// API controller for managing order details.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly ISender _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderDetailsController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator for sending commands and queries.</param>
    public OrderDetailsController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Gets all order details with pagination.
    /// </summary>
    /// <param name="paginationParams">The pagination parameters.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of order details.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams, CancellationToken cancellationToken)
    {
        var query = new GetOrderDetailsQuery(new GetOrderDetailsRequest(paginationParams));
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
    
    /// <summary>
    /// Imports order details from a request.
    /// </summary>
    /// <param name="orderDetailsRequest">The order details import request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>No content result.</returns>
    [HttpPost("import")]
    public async Task<IActionResult> Import(ImportOrderDetailsRequest orderDetailsRequest, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ImportOrderDetailsCommand(orderDetailsRequest), cancellationToken);
        return NoContent();
    }
}