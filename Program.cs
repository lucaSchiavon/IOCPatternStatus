
using TestAdvacedCsharpCode.Concrete;
using TestAdvacedCsharpCode.Extensions;
using TestAdvacedCsharpCode.Middlewares;
using TestAdvacedCsharpCode.Middlewares.Options;

namespace TestAdvacedCsharpCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
           

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            //app.UseMiddleware<RequestLoggerMiddleware>();

            app.UseRequestLogger(options =>
            {
                options.Logger = app.Services.GetRequiredService<ILogger<RequestLoggerMiddleware>>();
                options.LogStart = () => Console.WriteLine("Log is starting");
                options.LogDetails = context => Console.WriteLine($"Metodo: {context.Request.Method}, Path: {context.Request.Path}");
                options.FormatLogEntry = context => $"{DateTime.UtcNow} - {context.Request.Method} {context.Request.Path}";
            });

            //TrasformMiddlewareOptions options = new TrasformMiddlewareOptions { Transformer = new UppercaseTransformer() };
            ////options.Transformer = new UppercaseTransformer();
            //app.UseMiddleware<TransformMiddleware>(options);
            app.UseResponseTransformMiddleware(options =>
            {
                options.Transformer = new UppercaseTransformer();
            });

           

            app.MapControllers();

            app.Run();
        }
    }
}
