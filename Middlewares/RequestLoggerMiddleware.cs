using TestAdvacedCsharpCode.Middlewares.Options;

namespace TestAdvacedCsharpCode.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RequestLoggerMiddlewareOptions _options;

        public RequestLoggerMiddleware(RequestDelegate next, RequestLoggerMiddlewareOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _options.LogStart?.Invoke();
            _options.LogDetails?.Invoke(context);
            var logEntry=_options.FormatLogEntry?.Invoke(context);
            _options.Logger?.LogInformation(logEntry);

         await _next(context);

        }
    }
}
