using manageExceptions.CustomGlobalResponse;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace manageExceptions.GlobalExceptions;

/* First version No CustomResponse 
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Exception occurred",
            Type = "application/json"
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response
            .WriteAsJsonAsync(
                problemDetails,
                cancellationToken);
        return true;
    }
}
*/

/*Second version with CustomResponse */
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        CustomResponse<object> customResponse = new CustomResponse<object>(null)
        {
            Body = null,
            Error = new ErrorResponse
            {
                Code = StatusCodes.Status500InternalServerError,
                Message = "Exception occurred",
            }
        };

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response
            .WriteAsJsonAsync(
                customResponse,
                cancellationToken);
        return true;
    }
}

/* First version No CustomResponse 
public class CustomExceptionHandler : IExceptionHandler
{
    private readonly ILogger<CustomExceptionHandler> _logger;

    public CustomExceptionHandler(
        ILogger<CustomExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not CustomException customException)
        {
            return false;
        }

        _logger.LogError(
            customException,
            customException.Message);

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Custom Exception",
            Detail = customException.Message
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

}
*/

public class CustomExceptionHandler : IExceptionHandler
{
    private readonly ILogger<CustomExceptionHandler> _logger;

    public CustomExceptionHandler(
        ILogger<CustomExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not CustomException customException)
        {
            return false;
        }

        _logger.LogError(
            customException,
            customException.Message);

        CustomResponse<object> customResponse = new CustomResponse<object>(null)
        {
            Body = null,
            Error = new ErrorResponse
            {
                Code = StatusCodes.Status400BadRequest,
                Message = customException.Message,
            }
        };

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        await httpContext.Response
            .WriteAsJsonAsync(
                customResponse,
                cancellationToken);

        return true;
    }

}
