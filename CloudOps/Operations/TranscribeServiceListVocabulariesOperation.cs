using Amazon;
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class TranscribeServiceListVocabulariesOperation : Operation
    {
        public override string Name => "ListVocabularies";

        public override string Description => "Returns a list of vocabularies that match the specified criteria. If no criteria are specified, returns the entire list of vocabularies.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "TranscribeService";

        public override string ServiceID => "Transcribe";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonTranscribeServiceClient client = new AmazonTranscribeServiceClient(creds, region);
            ListVocabulariesResponse resp = new ListVocabulariesResponse();
            do
            {
                ListVocabulariesRequest req = new ListVocabulariesRequest
                {
                    NextToken = resp.NextToken,
                    MaxResults = maxItems
                };
                resp = client.ListVocabularies(req);
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