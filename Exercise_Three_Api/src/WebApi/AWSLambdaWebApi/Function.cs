using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AWSLambdaWebApi.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApi.Application.Contract;
using WebApi.DI;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaWebApi;

public class Function
{
    readonly ServiceProvider _serviceProvider;
    public Function()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddHttpClients();
        serviceCollection.AddApplicationServices();
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }


    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<APIGatewayProxyResponse> CurrentHistory(APIGatewayProxyRequest request, ILambdaContext context)
    {
        try
        {
            var option = request.QueryStringParameters["option"];

            if (option == null) return CreateReponse.HttpResponse(204, "No Content");


            using (var scope = _serviceProvider.CreateScope())
            {
                var someService = scope.ServiceProvider.GetRequiredService<ICurrencyHistoryService>();
                var result = await someService.GetCurrencyHistoryAsync(option);
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
