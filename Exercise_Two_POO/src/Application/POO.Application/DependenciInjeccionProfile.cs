using Microsoft.Extensions.DependencyInjection;
using POO.Application.Interfaces.Account;
using POO.Application.Interfaces.Clients;
using POO.Application.Interfaces.HistoryMovements;
using POO.Application.Interfaces.TransferAccount;
using POO.Application.Interfaces.WithdrawalAccount;
using POO.Application.Services.Account;
using POO.Application.Services.Clients;
using POO.Application.Services.HistoryMovements;
using POO.Application.Services.TransferAccount;
using POO.Application.Services.WithdrawalAccount;
using POO.Domain.Interfaces;
using POO.Domain.Services;

namespace POO.Application
{
    public static class DependenciInjeccionProfile
    {
        public static IServiceCollection AddServiceApplication(this IServiceCollection service)
        {
            service.AddTransient<IApplicationClients, ApplicationClients>();
            service.AddTransient<IApplicationWithdrawalAccount, ApplicationWithdrawalAccount>();
            service.AddTransient<IApplicationTransferAccount, ApplicationTransferAccount>();
            service.AddTransient<IApplicationAccount, ApplicationAccount>();
            service.AddTransient<IApplicationHistoryMovements, ApplicationHistoryMovements>();
            return service;
        }

        public static IServiceCollection AddServiceDomain(this IServiceCollection service)
        {
            service.AddTransient<IDomianHistoryMovements, DomianHistoryMovements> ();
            return service;
        }

        public static IServiceCollection AddServiceMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return service;
        }



    }
}
