using Amazon;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ElastiCacheDescribeReservedCacheNodesOperation : Operation
    {
        public override string Name => "DescribeReservedCacheNodes";

        public override string Description => "Returns information about reserved cache nodes for this account, or about a specified reserved cache node.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ElastiCache";

        public override string ServiceID => "ElastiCache";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonElastiCacheClient client = new AmazonElastiCacheClient(creds, region);
            ReservedCacheNodeMessage resp = new ReservedCacheNodeMessage();
            do
            {
                DescribeReservedCacheNodesMessage req = new DescribeReservedCacheNodesMessage
                {
                    Marker = resp.Marker,
                    MaxRecords = maxItems
                };
                resp = client.DescribeReservedCacheNodes(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.ReservedCacheNodes)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}