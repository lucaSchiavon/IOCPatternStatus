using TestAdvacedCsharpCode.Middlewares;
using TestAdvacedCsharpCode.Middlewares.Options;

namespace TestAdvacedCsharpCode.Extensions
{
    public static class TransformMiddlewareExtensions
    {
        public static void UseResponseTransformMiddleware(this IApplicationBuilder app, Action<TrasformMiddlewareOptions> setupAction)
        { 
        
            var options=new TrasformMiddlewareOptions();

            setupAction(options);

            if (options.Transformer == null)
                throw new ArgumentException("Trasformer must be set");

            app.UseMiddleware<TransformMiddleware>(options);
        }
    }
}
