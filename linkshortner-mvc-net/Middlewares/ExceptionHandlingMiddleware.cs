using System.Net;
using linkshortner_mvc_net.Exceptions;

namespace linkshortner_mvc_net.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var response = context.Response;
            
            // Get origin url of request to return the error to
            var redirectUrl = context.Request.Path.Value;
            
            switch (exception)
            {
                case PasswordsDoNotMatchException e:
                    response.Redirect($"{redirectUrl}/?message={e.Message}&messageType=error");
                    break;
                case UserAlreadyExistException e:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.Redirect($"{redirectUrl}/?message={e.Message}&messageType=error");
                    break;
                case NullEmailAndUsernameException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Redirect($"{redirectUrl}/?message={e.Message}&messageType=error");
                    break;
                case UserDoesNotExistException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Redirect($"{redirectUrl}/?message={e.Message}&messageType=error");
                    break;
                case WrongCredentialsException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Redirect($"{redirectUrl}/?message={e.Message}&messageType=error");
                    break;
                case UserIsAlreadyLoggedInException e:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.Redirect($"{redirectUrl}/?message={e.Message}&messageType=error");
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;           
                    // response.Redirect("/error");
                    response.WriteAsJsonAsync(exception.StackTrace);
                    break;
            }
        }

    }
}