using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class EC2DescribeVpcsOperation : Operation
    {
        public override string Name => "DescribeVpcs";

        public override string Description => "Describes one or more of your VPCs.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "EC2";

        public override string ServiceID => "EC2";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonEC2Client client = new AmazonEC2Client(creds, region);
            DescribeVpcsResultResponse resp = new DescribeVpcsResultResponse();
            DescribeVpcsRequest req = new DescribeVpcsRequest
            {                    
                                    
            };
            resp = client.DescribeVpcs(req);
            CheckError(resp.HttpStatusCode, "200");                
            
            foreach (var obj in resp.Vpcs)
            {
                AddObject(obj);
            }
            
        }
    }
}