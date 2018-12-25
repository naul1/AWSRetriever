using Amazon;
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CodeCommitListBranchesOperation : Operation
    {
        public override string Name => "ListBranches";

        public override string Description => "Gets information about one or more branches in a repository.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "CodeCommit";

        public override string ServiceID => "CodeCommit";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCodeCommitClient client = new AmazonCodeCommitClient(creds, region);
            Response resp = new Response();
            do
            {
                ListBranchesRequest req = new ListBranchesRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListBranches(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Branches)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}