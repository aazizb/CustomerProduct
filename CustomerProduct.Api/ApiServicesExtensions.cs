using CustomerProduct.Application;
using CustomerProduct.Infrastructure;
using CustomerProduct.Persistence;

using Serilog;
namespace CustomerProduct.Api
{
    public static class ApiServicesExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Host.UseSerilog();

            builder.Services.AddCors(options =>
            {               // should not in real application
                options.AddPolicy("AllowAll", policy =>
                    policy.AllowAnyOrigin()   // allow requests from any origin
                          .AllowAnyMethod()   // allow all HTTP methods 
                          .AllowAnyHeader()); // allow all headers
            });


            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseSerilogRequestLogging(); // logs HTTP Requests

            return app;
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCors("AllowAll");// should not in real application

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }

    }
}