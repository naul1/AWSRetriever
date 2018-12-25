using Amazon;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class DeviceFarmListUniqueProblemsOperation : Operation
    {
        public override string Name => "ListUniqueProblems";

        public override string Description => "Gets information about unique problems.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "DeviceFarm";

        public override string ServiceID => "Device Farm";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonDeviceFarmClient client = new AmazonDeviceFarmClient(creds, region);
            Response resp = new Response();
            do
            {
                ListUniqueProblemsRequest req = new ListUniqueProblemsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListUniqueProblems(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.UniqueProblems)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}