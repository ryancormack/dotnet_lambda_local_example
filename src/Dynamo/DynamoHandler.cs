using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.S3;
using Microsoft.Extensions.DependencyInjection;

namespace LambdaDotNetDebug.Dynamo
{
    public class DynamoHandler
    {
        private readonly IServiceProvider _serviceProvider = ServiceProviderBuilder.Configure().BuildServiceProvider();
        private readonly DynamoService _dynamoService;
        public DynamoHandler()
        {
            var s3 = _serviceProvider.GetService<IAmazonS3>();
            var mapper = _serviceProvider.GetService<IDynamoMapper>();
            _dynamoService = new DynamoService(s3, mapper);
        }

       public async Task EntryPoint(DynamoDBEvent stream)
       {
           var things = stream.Records.Select(r =>  _dynamoService.Process(r.Dynamodb));

           Console.WriteLine(things.Count());
       }
    }
}
