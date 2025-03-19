using CustomerProduct.Application;
using CustomerProduct.Persistence;
using CustomerProduct.Infrastructure;
using Serilog;
namespace CustomerProduct.Api
{
    public static class ApiExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Host.UseSerilog();

            var app = builder.Build();
            app.UseSerilogRequestLogging(); // Logs HTTP Requests

            return app;
        }

    }
}
