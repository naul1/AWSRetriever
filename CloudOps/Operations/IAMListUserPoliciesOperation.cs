using Amazon;
using Amazon.IAM;
using Amazon.IAM.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IAMListUserPoliciesOperation : Operation
    {
        public override string Name => "ListUserPolicies";

        public override string Description => "Lists the names of the inline policies embedded in the specified IAM user. An IAM user can also have managed policies attached to it. To list the managed policies that are attached to a user, use ListAttachedUserPolicies. For more information about policies, see Managed Policies and Inline Policies in the IAM User Guide. You can paginate the results using the MaxItems and Marker parameters. If there are no inline policies embedded with the specified user, the operation returns an empty list.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "IAM";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIAMClient client = new AmazonIAMClient(creds, region);
            ListUserPoliciesResponse resp = new ListUserPoliciesResponse();
            do
            {
                ListUserPoliciesRequest req = new ListUserPoliciesRequest
                {
                    Marker = resp.Marker,
                    MaxItems = maxItems
                };
                resp = client.ListUserPolicies(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.PolicyNames)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}