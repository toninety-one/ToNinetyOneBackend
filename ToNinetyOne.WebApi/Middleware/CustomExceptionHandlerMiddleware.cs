using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.WebApi.Middleware;

/// <summary>
///     Custom middleware handler
/// </summary>
public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    ///     Custom middleware constructor
    /// </summary>
    /// <param name="next"></param>
    public CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    ///     Custom middleware descriptor
    /// </summary>
    /// <param name="context"></param>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;

        switch (exception)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(validationException);
                break;
            case UnauthorizedAccessException unauthorizedAccessException:
                code = HttpStatusCode.Unauthorized;
                result = JsonSerializer.Serialize(unauthorizedAccessException);
                break;
            case NotAuthorizedException notAuthorizedException:
                code = HttpStatusCode.Unauthorized;
                result = JsonSerializer.Serialize(new
                    { error = notAuthorizedException?.Message ?? NotAuthorizedException.InvalidAuthData });
                break;
            case not null:
                result = JsonSerializer.Serialize(new { error = exception.Message });
                code = HttpStatusCode.NotFound;
                break;
            default:
                code = HttpStatusCode.InternalServerError;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}