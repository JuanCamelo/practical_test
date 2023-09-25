using Amazon.Lambda.APIGatewayEvents;

namespace AWSLambdaPOO.Helpers
{
    public static class Deseralize
    {
        public static R ProcessHttpBodyResult<R>(APIGatewayProxyRequest request) where R : class 
        {
            if (request.Body == null)
            {
                throw new Exception("El cuerpo de la solicitud es nulo.");
            }

            return System.Text.Json.JsonSerializer.Deserialize<R>(request.Body);
        }
    }
}
