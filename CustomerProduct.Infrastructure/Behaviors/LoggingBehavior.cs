using System.Diagnostics;

using MediatR;

using Microsoft.Extensions.Logging;

namespace CustomerProduct.Infrastructure
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            Logger = logger;
        }

        public ILogger<LoggingBehavior<TRequest, TResponse>> Logger { get; }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            Logger.LogInformation("Handling request: {RequestName} with data: {@Request}", requestName, request);

            var stopwatch = Stopwatch.StartNew();
            try
            {
                var response = await next();
                stopwatch.Stop();

                Logger.LogInformation("Handled request: {RequestName} - Execution Time: {ElapsedMilliseconds}ms - Response: {@Response}",
                    requestName, stopwatch.ElapsedMilliseconds, response);

                return response;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                Logger.LogError(ex, "Request {RequestName} failed after {ElapsedMilliseconds}ms with error: {ErrorMessage}",
                    requestName, stopwatch.ElapsedMilliseconds, ex.Message);

                throw; // Re-throw the exception to let global exception middleware handle it
            }
        }
    }

}
