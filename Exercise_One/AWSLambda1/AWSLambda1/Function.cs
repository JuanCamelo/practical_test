using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AWSLambda1.Contract;
using AWSLambda1.DI;
using AWSLambda1.Helpers;
using Microsoft.Extensions.DependencyInjection;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambda1;

public class Function
{

    readonly ServiceProvider _serviceProvider;
    public Function()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddApplicationService();
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    public async Task<APIGatewayProxyResponse> ProjectInformation(APIGatewayProxyRequest request, ILambdaContext context)
    {
        try
        {
            var option = request.QueryStringParameters["option"];

            if (option == null) return CreateReponse.HttpResponse(204, "No Content");


            using (var scope = _serviceProvider.CreateScope())
            {
                var someService = scope.ServiceProvider.GetRequiredService<IApplicationProjectInformation>();
                var result = await someService.GetProjectInformation(option);
                if (result != null)
                    return CreateReponse.HttpResponse(200, result);
            }

            return CreateReponse.HttpResponse(200, "No Content");
        }
        catch (Exception ex)
        {
            return CreateReponse.HttpResponse(409, ex.Message);
        }
    }



}
