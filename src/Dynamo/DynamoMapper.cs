using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;

namespace LambdaDotNetDebug.Dynamo
{
    public class DynamoMapper : IDynamoMapper
    {
        public MyEntity MapToRecord(Dictionary<string, AttributeValue> dynamoImage)
        {
            var id = dynamoImage.ContainsKey("id") ? dynamoImage["id"].N : null;
            var data = dynamoImage.ContainsKey("myAttr") ? dynamoImage["myAttr"].S : null;
            if (id is null && data is null) return default(MyEntity);

            return new MyEntity()
            {
                Id = id,
                Data = data
            };
        }
    }

    public interface IDynamoMapper
    {
        MyEntity MapToRecord(Dictionary<string, AttributeValue> dynamoImage);
    }
}