using CustomerProduct.Application;
using CustomerProduct.Persistence;

namespace CustomerProduct.Api
{
    public static class ApiExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);

            return builder.Build();
        }

    }
}
