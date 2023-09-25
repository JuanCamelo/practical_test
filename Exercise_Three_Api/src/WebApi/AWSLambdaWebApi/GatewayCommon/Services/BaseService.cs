using System.Text.Json;

namespace WebApi.GatewayCommon.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient _client;

        protected BaseService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://api.exchangeratesapi.io/v1/");
        }
        protected async Task<R> DoGet<R>(string url)
        {
            var httpResponse = await _client.GetAsync($"{url}access_key=06eded7420a54defb73a7f14c58d1518");
            return await ProcessHttpResult<R>(httpResponse);
        }
        private static async Task<R> ProcessHttpResult<R>(HttpResponseMessage httpResponse)
        {
            if (!httpResponse.IsSuccessStatusCode)
            {
                var error = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(error);
            }

            return JsonSerializer.Deserialize<R>(await httpResponse.Content.ReadAsStringAsync());
        }
    }
}
