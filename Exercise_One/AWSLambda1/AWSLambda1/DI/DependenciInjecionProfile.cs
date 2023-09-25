using AWSLambda1.Application;
using AWSLambda1.Contract;
using AWSLambda1.Repository.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace AWSLambda1.DI
{
    public static class DependenciInjecionProfile
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection service)
        {
            _ = service ?? throw new ArgumentNullException(nameof(service));
            service.AddTransient<IApplicationProjectInformation, ApplicationProjectInformation>();
            service.AddTransient<IRepository, Repository.Repository>();
            return service;
        }

    }
}
