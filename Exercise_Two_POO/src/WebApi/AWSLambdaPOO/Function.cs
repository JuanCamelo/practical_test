using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AWSLambdaPOO.Helpers;
using Microsoft.Extensions.DependencyInjection;
using POO.Application;
using POO.Application.DTOs.Request;
using POO.Application.Interfaces.Clients;
using POO.Application.Interfaces.HistoryMovements;
using POO.Application.Interfaces.TransferAccount;
using POO.Application.Interfaces.WithdrawalAccount;
using POO.Infraestructure.Extensions;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaPOO;

public class Function
{
    readonly ServiceProvider _serviceProvider;
    public Function()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextInfra();
        serviceCollection.AddServicesInfra();
        serviceCollection.AddServiceMapper();
        serviceCollection.AddServiceApplication();
        serviceCollection.AddServiceDomain();
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }


    public async Task<APIGatewayProxyResponse> FunctionHandlerClients(APIGatewayProxyRequest request, ILambdaContext context)
    {
        try
        {
            var httpMethod = request.HttpMethod;

            using (var scope = _serviceProvider.CreateScope())
            {
                var someService = scope.ServiceProvider.GetRequiredService<IApplicationClients>();

                if (httpMethod == "GET")
                {
                    var result = await someService.GetAsync();
                    return CreateReponse.HttpResponse(200, result);
                }

                if (httpMethod == "POST")
                {
                    var body = Deseralize.ProcessHttpBodyResult<ModelAccountClient>(request);
                    if (string.IsNullOrEmpty(body.Client) && body.Document == 0 && string.IsNullOrEmpty(body.TypeAccount))
                        return CreateReponse.HttpResponse(409, "Usuario no valido los campos, Client, Document, TypeAccount no pueden ser vacios");

                    var result = await someService.AddAsync(body);
                    return CreateReponse.HttpResponse(201, body);
                }
            }

            return CreateReponse.HttpResponse(200, "No Content");
        }
        catch (Exception ex)
        {
            return CreateReponse.HttpResponse(409, ex.Message);
        }
    }

    public async Task<APIGatewayProxyResponse> FunctionHandlerHistoryMovements(APIGatewayProxyRequest request, ILambdaContext context)
    {
        try
        {
            var httpMethod = request.HttpMethod;

            if (httpMethod == "GET")
            {
                var idDocument = request.QueryStringParameters["idDocument"];
                using (var scope = _serviceProvider.CreateScope())
                {
                    var someService = scope.ServiceProvider.GetRequiredService<IApplicationHistoryMovements>();

                    if (!string.IsNullOrEmpty(idDocument))
                    {
                        var result = await someService.HistoryMovementsAsync(Convert.ToInt32(idDocument));
                        return CreateReponse.HttpResponse(200, result);
                    }

                }
            }
            return CreateReponse.HttpResponse(200, "No Content");
        }
        catch (Exception ex)
        {
            return CreateReponse.HttpResponse(409, ex.Message);
        }
    }

    public async Task<APIGatewayProxyResponse> FunctionHandlerTransferAccount(APIGatewayProxyRequest request, ILambdaContext context)
    {
        try
        {
            var httpMethod = request.HttpMethod;

            using (var scope = _serviceProvider.CreateScope())
            {
                var someService = scope.ServiceProvider.GetRequiredService<IApplicationTransferAccount>();

                if (httpMethod == "POST")
                {
                    var body = Deseralize.ProcessHttpBodyResult<ModelAccountTransfer>(request);
                    var result = await someService.CreateTransferAccount(body);
                    return CreateReponse.HttpResponse(201, result);
                }

            }

            return CreateReponse.HttpResponse(200, "No Content");
        }
        catch (Exception ex)
        {
            return CreateReponse.HttpResponse(409, ex.Message);
        }
    }

    public async Task<APIGatewayProxyResponse> FunctionHandlerWithdrawalAccount(APIGatewayProxyRequest request, ILambdaContext context)
    {
        try
        {
            var httpMethod = request.HttpMethod;

            using (var scope = _serviceProvider.CreateScope())
            {
                var someService = scope.ServiceProvider.GetRequiredService<IApplicationWithdrawalAccount>();

                if (httpMethod == "POST")
                {
                    var body = Deseralize.ProcessHttpBodyResult<ModelAccountWithdrawal>(request);
                    var result = await someService.CreateWithdrawalAccount(body);
                    return CreateReponse.HttpResponse(201, result);
                }
            }

            return CreateReponse.HttpResponse(200, "No Content");
        }
        catch (Exception ex)
        {
            return CreateReponse.HttpResponse(409, ex.Message);
        }
    }
}
