namespace WebApi.Application.Contract
{
    public interface ICurrencyHistoryService
    {
        Task<object?> GetCurrencyHistoryAsync(string query);
    }
}
