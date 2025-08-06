using Microsoft.Extensions.Options;
using TestAdvacedCsharpCode.Middlewares;
using TestAdvacedCsharpCode.Middlewares.Options;

namespace TestAdvacedCsharpCode.Extensions
{
    public static class RequestLoggerMiddlewareExtensions
    {
        public static void UseRequestLogger(this IApplicationBuilder app, Action<RequestLoggerMiddlewareOptions> setupAction)
        { 
            var options=new RequestLoggerMiddlewareOptions();

            setupAction.Invoke(options);

            if (options.Logger == null)
                throw new ArgumentException("Logger must be set");
            //iiiii
            app.UseMiddleware<RequestLoggerMiddleware>(options);
        }
    }
}
