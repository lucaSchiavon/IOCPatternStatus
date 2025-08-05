
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
