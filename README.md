Applicazione dell IOC mediante un metodo abstract che viene implementato esternamente (utile tecnica per implementare librerie in modo da poter definire la logica di metodi che poi vengono chiamati internamente da classi dove sono stati definiti come abstract

Altra cosa che viene dimostrata: il passaggio di opzioni a middleware custom:
il passaggio delle opzioni avviene mediante semplice oggetto:

  app.UseResponseTransformMiddleware(options =>
            {
                options.Transformer = new UppercaseTransformer();
            });

o attraverso delegate (abbiamo istanza Object, Action, Action<T>, Func<T,TResult>):

 app.UseRequestLogger(options =>
            {
                options.Logger = app.Services.GetRequiredService<ILogger<RequestLoggerMiddleware>>();
                options.LogStart = () => Console.WriteLine("Log is starting");
                options.LogDetails = context => Console.WriteLine($"Metodo: {context.Request.Method}, Path: {context.Request.Path}");
                options.FormatLogEntry = context => $"{DateTime.UtcNow} - {context.Request.Method} {context.Request.Path}";
            });



