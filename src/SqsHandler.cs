using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

namespace LambdaDotNetDebug
{
    public class SqsHandler
    {
       public async Task EntryPoint(SQSEvent request)
       {
           var myData = JsonSerializer.Deserialize<MySqsEvent>(request.Records[0].Body);
           var env = Environment.GetEnvironmentVariable("SOME_ENV_VAR") ?? "not found";
       }
    }

    public class MySqsEvent
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
