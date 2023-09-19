namespace WebApi.Extensions
{
    public static class ExchangeratesGatewayServices
    {
        public static string ExchangeratesUrl { get; set; }

        public static HttpClient ConfigureExchangeratesGatewayClient(this HttpClient client)
        {
            client.BaseAddress = new Uri(ExchangeratesUrl);

            return client;
        }
    }
}
