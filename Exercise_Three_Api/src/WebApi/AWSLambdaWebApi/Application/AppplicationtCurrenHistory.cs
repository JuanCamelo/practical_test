using AWSLambdaWebApi.Domain.Strategy;
using WebApi.Application.Contract;
using WebApi.Services;

namespace WebApi.Application
{
    public class AppplicationtCurrenHistory : ICurrencyHistoryService
    {
        private readonly ICurrencyHistory _currencyHistory;

        public AppplicationtCurrenHistory(ICurrencyHistory currencyHistory)
        {
            _currencyHistory= currencyHistory;
        }

        public async Task<object?> GetCurrencyHistoryAsync(string option)
        {
            try
            {
                if(option.ToUpper() == "lastYearHistory".ToUpper())
                {
                    var result = new LastYearHistoryQuery();
                    return await result.ExecuteAsync(_currencyHistory);
                }
                if (option.ToUpper() == "convertHistory".ToUpper())
                {
                    var result = new ConvertHistoryQuery();
                    return await result.ExecuteAsync(_currencyHistory);
                }
                if (option.ToUpper() == "timeseriesHistory".ToUpper())
                {
                    var result = new TimeseriesHistoryQuery();
                    return await result.ExecuteAsync(_currencyHistory);
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
