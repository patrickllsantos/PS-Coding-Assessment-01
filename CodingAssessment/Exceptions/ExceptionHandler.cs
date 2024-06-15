using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Exceptions;

/// <summary>
/// Global exception handler for managing and logging exceptions in the application.
/// </summary>
public class ExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger to log exception details.</param>
    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Tries to handle the exception and generate an appropriate HTTP response.
    /// </summary>
    /// <param name="httpContext">The HTTP context in which the exception occurred.</param>
    /// <param name="exception">The exception that was thrown.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A value task representing whether the exception was handled.</returns>
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        var problemDetails = new ProblemDetails
        {
            Title = "An error occurred while processing your request.",
            Detail = exception.Message,
            Instance = httpContext.Request.Path
        };

        switch (exception)
        {
            case ValidationException validationException:
                problemDetails.Title = "Validation error.";
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Extensions["errors"] = validationException.Errors;
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            case CsvProcessingException when exception.InnerException is CategoryNotFoundException categoryNotFoundException:
                problemDetails.Title = "Category not found.";
                problemDetails.Detail = categoryNotFoundException.Message;
                problemDetails.Status = StatusCodes.Status400BadRequest;
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            case CsvProcessingException when exception.InnerException is PizzaTypeNotFoundException pizzaTypeNotFoundException:
                problemDetails.Title = "Pizza type not found.";
                problemDetails.Detail = pizzaTypeNotFoundException.Message;
                problemDetails.Status = StatusCodes.Status400BadRequest;
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            case CsvProcessingException when exception.InnerException is InvalidSizeException invalidSizeException:
                problemDetails.Title = "Invalid size.";
                problemDetails.Detail = invalidSizeException.Message;
                problemDetails.Status = StatusCodes.Status400BadRequest;
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
            case CsvProcessingException:
                problemDetails.Title = "An error occurred while importing the data";
                problemDetails.Detail = exception.Message;
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
            default:
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
        
        problemDetails.Extensions["traceId"] = traceId;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
