namespace Hotel_Management_Software.Middleware;

using System.Net;
using Hotel_Management_Software.BBL.Exceptions;
using Newtonsoft.Json;



public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        string message;
        int statusCode;

        if (exception is CustomException customException)
        {
           
            message = customException.Message;
            statusCode = customException.StatusCode;
        }
        else
        {
           
            switch (exception)
            {
                case UnauthorizedAccessException _:
                    message = "Unauthorized access.";
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case KeyNotFoundException _:
                    message = "Resource not found.";
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    message = exception.Message;
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var result = JsonConvert.SerializeObject(new { error = message });
        return context.Response.WriteAsync(result);
    }
}
