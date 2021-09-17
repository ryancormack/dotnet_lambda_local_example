using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace LambdaDotNetDebug
{
    public class ApiGwHandler
    {
       public async Task<APIGatewayProxyResponse> EntryPoint(APIGatewayProxyRequest request)
       {
           var myData = JsonSerializer.Deserialize<MyCustomRequest>(request.Body);
           var env = Environment.GetEnvironmentVariable("SOME_ENV_VAR") ?? "not found";

           return new APIGatewayProxyResponse()
           {
               Body = $"Your data was {myData.Value} and the Env var is {env}",
               StatusCode = (int)HttpStatusCode.OK
           };
       }
    }

    public class MyCustomRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
