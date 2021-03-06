using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.EC2
{
    public class DescribeSpotFleetRequestsOperation : Operation
    {
        public override string Name => "DescribeSpotFleetRequests";

        public override string Description => "Describes your Spot Fleet requests. Spot Fleet requests are deleted 48 hours after they are canceled and their instances are terminated.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Config config = new AmazonEC2Config();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonEC2Client client = new AmazonEC2Client(creds, config);
            
            DescribeSpotFleetRequestsResponse resp = new DescribeSpotFleetRequestsResponse();
            do
            {
                DescribeSpotFleetRequestsRequest req = new DescribeSpotFleetRequestsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeSpotFleetRequests(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.SpotFleetRequestConfigs)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}