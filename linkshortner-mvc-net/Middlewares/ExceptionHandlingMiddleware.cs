using System.Net;
using linkshortner_mvc_net.Exceptions;
using linkshortner_mvc_net.Models;

namespace linkshortner_mvc_net.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger _logger;

    public ExceptionHandlingMiddleware(ILogger logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            next(context);
        }
        catch (Exception exception)
        {
            var errorResult = new ErrorResultModel();
            switch (exception)
            {
                case UserNotFoundException e:
                    errorResult.Message = e.Message;
                    errorResult.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    errorResult.Message = "There was an internal server error";
                    errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.LogError
                ($"There was an error with code {errorResult.StatusCode} and trace {exception.StackTrace}");
            var response = context.Response;
            if (response.HasStarted)
            {
                response.ContentType = "application/json";
                response.StatusCode = errorResult.StatusCode;
                await response.WriteAsJsonAsync(errorResult);
            }
            else
            {
                _logger.LogWarning("Can't write to response");
            }
        }
    }
}