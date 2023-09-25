using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POO.Domain.Interfaces;
using POO.Infraestructure.Context;
using POO.Infraestructure.Interfaces;
using POO.Infraestructure.Repositories;

namespace POO.Infraestructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContextInfra(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            var connectionString = "Server=database.clfyixnbaq8f.us-east-1.rds.amazonaws.com,1433;Database=Application;User=adminj;Password=Pruebas1; TrustServerCertificate=True";

            return services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(connectionString));
        }

        public static IServiceCollection AddServicesInfra(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
