using Microsoft.Extensions.DependencyInjection;

namespace CustomerProduct.Application
{
    public static class ApplicationServices
    {
        /// <summary>
        /// extension method to register services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        { 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(o => o.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            return services;
        } 
    }
}
