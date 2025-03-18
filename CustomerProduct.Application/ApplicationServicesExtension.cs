using Microsoft.Extensions.DependencyInjection;

namespace CustomerProduct.Application
{
    public static class ApplicationServicesExtension
    {
        /// <summary>
        /// extension method to register application services
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
