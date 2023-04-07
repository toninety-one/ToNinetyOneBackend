namespace ToNinetyOne.WebApi.Middleware;

/// <summary>
/// Custom middleware extension
/// </summary>
public static class CustomExceptionHandlerMiddlewareExtensions
{
    /// <summary>
    /// Custom builder exception that use middleware
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}