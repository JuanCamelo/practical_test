using AWSLambdaWebApi.Domain.Contract;
using WebApi.Application.Contract;
using WebApi.Services;

namespace AWSLambdaWebApi.Domain.Strategy
{
    public class LastYearHistoryQuery : IHistoryQueryStrategy
    {
        public async Task<object> ExecuteAsync(ICurrencyHistory currencyHistoryService)
        {
            string query = "2013-03-16&symbols=USD,AUD,CAD,PLN,MXN,EUR,COP&format=1?";
            var result = await currencyHistoryService.GetCurrencyHistoryAsync(query);

            // Aquí puedes realizar la transformación del resultado si es necesario

            return result;
        }
    }
}
