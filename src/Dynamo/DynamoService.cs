using System;
using Amazon.DynamoDBv2.Model;
using Amazon.S3;

namespace LambdaDotNetDebug.Dynamo
{
    public class DynamoService
    {
        private readonly IAmazonS3 _s3;
        private readonly IDynamoMapper _mapper;
        public DynamoService(IAmazonS3 s3, 
            IDynamoMapper mapper)
        {
            _s3 = s3;
            _mapper = mapper;
        }

        public MyRecord Process(StreamRecord record)
        {
            var myRecord = new MyRecord()
            {
                NewItem = _mapper.MapToRecord(record.NewImage),
                OldItem = _mapper.MapToRecord(record.OldImage)
            };

            Console.WriteLine(myRecord.NewItem?.Data);

            return myRecord;
        }
    }
}