using System.Text;
using TestAdvacedCsharpCode.Base;
using TestAdvacedCsharpCode.Middlewares.Options;

namespace TestAdvacedCsharpCode.Middlewares
{
    public class TransformMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ResponseTransformer _transformer;
        public TransformMiddleware(RequestDelegate next, TrasformMiddlewareOptions options)
        {
            _next = next;
            _transformer=options.Transformer;
        }
        public async Task Invoke(HttpContext context)
        {
            //cattura la response
            var originalBodyStream=context.Response.Body;
            //pulisce la response
            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            //controller scrive la sua risposta nel memorystream
            await _next(context);

            memoryStream.Seek(0, SeekOrigin.Begin);
            var responseBody = new StreamReader(memoryStream).ReadToEnd();
            //qui dal middleware viene chiamto il metodo di trasformazione configurato in fase di option nelle classi concrete
            //la implementazione avviene esternamente ma qui viene invocato il metodo
            var transformed = _transformer.Transform(responseBody);

            // Scrivi la risposta trasformata
            var transformedBytes = Encoding.UTF8.GetBytes(transformed);

            context.Response.Body = originalBodyStream;
            context.Response.ContentLength = transformedBytes.Length;
            await context.Response.Body.WriteAsync(transformedBytes, 0, transformedBytes.Length);
        }
    }
}
