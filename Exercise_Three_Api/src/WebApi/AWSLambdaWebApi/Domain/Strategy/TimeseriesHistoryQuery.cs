using AWSLambdaWebApi.Domain.Contract;
using WebApi.Application.Contract;
using WebApi.Services;

namespace AWSLambdaWebApi.Domain.Strategy
{
    internal class TimeseriesHistoryQuery : IHistoryQueryStrategy
    {
        public async Task<object> ExecuteAsync(ICurrencyHistory currencyHistoryService)
        {
            string query = "timeseries&start_date=2015-01-01&end_date=2015-02-01&base=EUR&symbols=USD,AUD,CAD,PLN,MXN&format=1?";
            return await currencyHistoryService.GetCurrencyHistoryAsync(query);
        }
    }
}
