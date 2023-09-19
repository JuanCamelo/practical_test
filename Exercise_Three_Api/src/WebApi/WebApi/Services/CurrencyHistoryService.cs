﻿using WebApi.GatewayCommon.Services;
using WebApi.Models;

namespace WebApi.Services
{
    public interface ICurrencyHistory
    {
        Task<CurrencyHistoryViewModel> GetCurrencyHistoryAsync(string query);
    }
    public class CurrencyHistoryService :BaseService, ICurrencyHistory
    {
        public CurrencyHistoryService(HttpClient client) : base(client) { }
        public async Task<CurrencyHistoryViewModel> GetCurrencyHistoryAsync(string query)
        => await DoGet<CurrencyHistoryViewModel>(query);
            
    }
}
