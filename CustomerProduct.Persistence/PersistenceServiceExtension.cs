using CustomerProduct.Application.Contracts.Persistence;
using CustomerProduct.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerProduct.Persistence
{
    public static class PersistenceServiceExtension
    {
        /// <summary>
        /// extension method to register persistence services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<CustomerProductDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("CustomeProductCS")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
