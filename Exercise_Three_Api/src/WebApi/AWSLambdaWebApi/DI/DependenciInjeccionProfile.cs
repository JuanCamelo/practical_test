using WebApi.Application.Contract;
using WebApi.Application;
using WebApi.Extensions;
using WebApi.Services;
using Microsoft.Extensions.DependencyInjection;
using AWSLambdaWebApi.Domain.Contract;
using AWSLambdaWebApi.Domain.Strategy;

namespace WebApi.DI
{
    public static class DependenciInjeccionProfile
    {

        public static IServiceCollection AddHttpClients(this IServiceCollection service)
        {
            _ = service ?? throw new ArgumentNullException(nameof(service));
            
            service.AddTransient<ICurrencyHistory, CurrencyHistoryService>();

            return service;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            _ = service ?? throw new ArgumentNullException(nameof(service));

            service.AddTransient<ICurrencyHistoryService ,AppplicationtCurrenHistory> ();
            service.AddTransient<IHistoryQueryStrategy, ConvertHistoryQuery>();
            service.AddTransient<IHistoryQueryStrategy, LastYearHistoryQuery>();
            service.AddTransient<IHistoryQueryStrategy,TimeseriesHistoryQuery>();

            return service;
        }
    }
}
