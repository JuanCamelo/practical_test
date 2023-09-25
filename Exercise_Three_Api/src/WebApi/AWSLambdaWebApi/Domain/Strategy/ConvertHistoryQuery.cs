using AWSLambdaWebApi.Domain.Contract;
using WebApi.Application.Contract;
using WebApi.Services;

namespace AWSLambdaWebApi.Domain.Strategy
{
    public class ConvertHistoryQuery : IHistoryQueryStrategy
    {
        public async Task<object> ExecuteAsync(ICurrencyHistory currencyHistoryService)
        {
            string query = "convert&from=USD&to=EUR&amount=25&format=1?";
            return await currencyHistoryService.GetCurrencyHistoryAsync(query);
        }
    }
}
