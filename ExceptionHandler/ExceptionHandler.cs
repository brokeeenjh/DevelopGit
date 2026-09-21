using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandler;

public class ExceptionHandler
{
    public RequestDelegate _next;
    public ILogger<ExceptionHandler> _logger;
    public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);

            context.Response.StatusCode = e switch
            {
                ApplicationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Type = e.GetType().Name,
                Title = "An error occured",
                Detail = e.Message
            });
        }
    }
}