using WebApi.Models;

namespace WebApi.Application.Contract
{
    public interface IAppplicationtCurrenHistory
    {
        Task<IEnumerable<CurrencyExchangeRateViewModel>> LastYearHistoryAsync();
        Task<object> HistoryRatesConversionAsync();
        Task<object> HistoryTiemeseriesAsync();
    }
}
