using WebApi.Application.Contract;
using WebApi.Application;
using WebApi.Extensions;
using WebApi.Services;

namespace WebApi.DI
{
    public static class DependenciInjeccionProfile
    {

        public static IServiceCollection AddHttpClients(this IServiceCollection service, IConfiguration configuration)
        {
            _ = service ?? throw new ArgumentNullException(nameof(service));


            ExchangeratesGatewayServices.ExchangeratesUrl = configuration.GetValue<string>("ExchangeratesUrl");
            service.AddHttpClient("ExchangeratesGatewayClient", client => client.ConfigureExchangeratesGatewayClient())
                   .AddTypedClient<ICurrencyHistory, CurrencyHistoryService>()
                   .SetHandlerLifetime(TimeSpan.FromMinutes(5));

            return service;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            _ = service ?? throw new ArgumentNullException(nameof(service));

            service.AddTransient<IAppplicationtCurrenHistory ,AppplicationtCurrenHistory> ();

            return service;
        }
    }
}
