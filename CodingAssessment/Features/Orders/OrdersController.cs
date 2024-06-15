using CodingAssessment.Features.Orders.GetOrders;
using CodingAssessment.Features.Orders.ImportOrders;
using CodingAssessment.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Features.Orders;

/// <summary>
/// API controller for managing orders.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ISender _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrdersController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator for sending commands and queries.</param>
    public OrdersController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Gets all orders with pagination.
    /// </summary>
    /// <param name="paginationParams">The pagination parameters.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of orders with pagination metadata.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams,
        CancellationToken cancellationToken)
    {
        var query = new GetOrdersQuery(new GetOrdersRequest(paginationParams));
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Imports orders from a request.
    /// </summary>
    /// <param name="ordersRequest">The order import request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>No content result.</returns>
    [HttpPost("import")]
    public async Task<IActionResult> Import(ImportOrdersRequest ordersRequest, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ImportOrdersCommand(ordersRequest), cancellationToken);
        return NoContent();
    }
}
