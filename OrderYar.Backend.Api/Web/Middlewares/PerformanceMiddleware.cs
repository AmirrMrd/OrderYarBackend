using System.Diagnostics;

namespace OrderYar.Backend.Api.Web.Middlewares;

public class PerformanceMiddleware : IMiddleware
{
    private readonly ILogger<PerformanceMiddleware> _logger;

    public PerformanceMiddleware(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<PerformanceMiddleware>();
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();

        await next(context);

        stopwatch.Stop();
        TimeSpan timeTaken = stopwatch.Elapsed;

        string requestPath = context.Request.Path;
        string method = context.Request.Method;

        _logger.LogInformation("Request {method} {path} took {timeTaken} ms", method, requestPath, timeTaken.TotalMilliseconds);
    }
}
