using Amazon;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SageMakerListLabelingJobsForWorkteamOperation : Operation
    {
        public override string Name => "ListLabelingJobsForWorkteam";

        public override string Description => "Gets a list of labeling jobs assigned to a specified work team.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "SageMaker";

        public override string ServiceID => "SageMaker";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSageMakerClient client = new AmazonSageMakerClient(creds, region);
            ListLabelingJobsForWorkteamResponse resp = new ListLabelingJobsForWorkteamResponse();
            do
            {
                ListLabelingJobsForWorkteamRequest req = new ListLabelingJobsForWorkteamRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListLabelingJobsForWorkteam(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}