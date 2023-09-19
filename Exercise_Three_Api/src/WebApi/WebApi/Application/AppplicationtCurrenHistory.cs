using WebApi.Application.Contract;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Application
{
    public class AppplicationtCurrenHistory : IAppplicationtCurrenHistory
    {
        private readonly ICurrencyHistory _currencyHistoryService;

        public AppplicationtCurrenHistory(ICurrencyHistory currencyHistoryService)
        {
            _currencyHistoryService = currencyHistoryService;
        }

        public async Task<object> HistoryRatesConversionAsync()
        {
            try
            {
                string query = "convert&from=USD&to=EUR&amount=25&format=1?";
                var result = await _currencyHistoryService.GetCurrencyHistoryAsync(query);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<object> HistoryTiemeseriesAsync()
        {
            try
            {
                string query = "timeseries&start_date=2015-01-01&end_date=2015-02-01&base=EUR&symbols=USD,AUD,CAD,PLN,MXN&format=1?";
                var result = await _currencyHistoryService.GetCurrencyHistoryAsync(query);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CurrencyExchangeRateViewModel>> LastYearHistoryAsync()
        {
            try
            {
                string query = "2013-03-16&symbols=USD,AUD,CAD,PLN,MXN,EUR,COP&format=1?";
                var result = await _currencyHistoryService.GetCurrencyHistoryAsync(query);

                List<CurrencyExchangeRateViewModel> exchangeRates = new List<CurrencyExchangeRateViewModel>
                {
                    new CurrencyExchangeRateViewModel { CurrencyPair = "USDCOP", Rate = result.Rates["USD"]+ " - "+ result.Rates["COP"]  },
                    new CurrencyExchangeRateViewModel { CurrencyPair = "EURCOP", Rate = result.Rates["EUR"]+ " - "+  result.Rates["COP"] },
                    new CurrencyExchangeRateViewModel { CurrencyPair = "MXNCOP", Rate = result.Rates["MXN"]+ " - "+ result.Rates["COP"] },
                    new CurrencyExchangeRateViewModel { CurrencyPair = "COPUSD", Rate = result.Rates["COP"]+ " - "+  result.Rates["USD"] },
                    new CurrencyExchangeRateViewModel { CurrencyPair = "COPMXN", Rate = result.Rates["COP"]+ " - "+ result.Rates["MXN"] },
                    new CurrencyExchangeRateViewModel { CurrencyPair = "COPEUR", Rate = result.Rates["COP"]+ " - "+  result.Rates["EUR"] }
                };
                return exchangeRates;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
