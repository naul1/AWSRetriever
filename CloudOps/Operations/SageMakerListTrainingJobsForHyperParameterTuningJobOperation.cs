using Amazon;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class SageMakerListTrainingJobsForHyperParameterTuningJobOperation : Operation
    {
        public override string Name => "ListTrainingJobsForHyperParameterTuningJob";

        public override string Description => "Gets a list of TrainingJobSummary objects that describe the training jobs that a hyperparameter tuning job launched.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "SageMaker";

        public override string ServiceID => "SageMaker";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonSageMakerClient client = new AmazonSageMakerClient(creds, region);
            Response resp = new Response();
            do
            {
                ListTrainingJobsForHyperParameterTuningJobRequest req = new ListTrainingJobsForHyperParameterTuningJobRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.ListTrainingJobsForHyperParameterTuningJob(req);
                CheckError(resp.HttpStatusCode, "200");                
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}