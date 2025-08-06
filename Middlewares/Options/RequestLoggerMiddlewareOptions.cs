namespace TestAdvacedCsharpCode.Middlewares.Options
{
    public class RequestLoggerMiddlewareOptions
    {
        public ILogger Logger { get; set; }
        public Action LogStart { get; set; }
        public Action<HttpContext>LogDetails { get; set; }
        public Func<HttpContext,string> FormatLogEntry { get; set; }
    }
}
