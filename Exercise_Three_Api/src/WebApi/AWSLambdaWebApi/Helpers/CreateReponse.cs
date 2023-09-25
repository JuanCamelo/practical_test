using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

namespace AWSLambdaWebApi.Helpers
{
    public static class CreateReponse
    {
        public static APIGatewayProxyResponse HttpResponse(int statusCode, object body)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = statusCode,
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" }
                },
                Body = JsonConvert.SerializeObject(body),
                IsBase64Encoded = false
            };
        }
    }
}
