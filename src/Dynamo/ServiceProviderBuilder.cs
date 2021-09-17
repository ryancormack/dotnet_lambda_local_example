using System;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.S3;
using Microsoft.Extensions.DependencyInjection;

namespace LambdaDotNetDebug.Dynamo
{
    public static class ServiceProviderBuilder
    {
        public static ServiceCollection Configure()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDefaultAWSOptions(new AWSOptions
            {
                DefaultClientConfig = { MaxErrorRetry = 5 },
                Region = RegionEndpoint.GetBySystemName(Environment.GetEnvironmentVariable("AWS_REGION"))
            });
            serviceCollection
                .AddSingleton<IDynamoMapper, DynamoMapper>()
                .AddAWSService<IAmazonS3>();

            return serviceCollection;
        }
    }
}