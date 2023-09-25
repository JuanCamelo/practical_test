using WebApi.Application.Contract;
using WebApi.Services;

namespace AWSLambdaWebApi.Domain.Contract
{
    public interface IHistoryQueryStrategy
    {
        Task<object> ExecuteAsync(ICurrencyHistory currencyHistoryService);
    }
}
