using Amazon;
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class IdentityManagementSimulateCustomPolicyOperation : Operation
    {
        public override string Name => "SimulateCustomPolicy";

        public override string Description => "Simulate how a set of IAM policies and optionally a resource-based policy works with a list of API operations and AWS resources to determine the policies&#39; effective permissions. The policies are provided as strings. The simulation does not perform the API operations; it only checks the authorization to determine if the simulated policies allow or deny the operations. If you want to simulate existing policies attached to an IAM user, group, or role, use SimulatePrincipalPolicy instead. Context keys are variables maintained by AWS and its services that provide details about the context of an API query request. You can use the Condition element of an IAM policy to evaluate context keys. To get the list of context keys that the policies require for correct simulation, use GetContextKeysForCustomPolicy. If the output is long, you can use MaxItems and Marker parameters to paginate the results.";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "IdentityManagement";

        public override string ServiceID => "IAM";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonIdentityManagementClient client = new AmazonIdentityManagementClient(creds, region);
            Response resp = new Response();
            do
            {
                SimulateCustomPolicyRequest req = new SimulateCustomPolicyRequest
                {
                    Marker = resp.Marker
                    ,
                    MaxItems = maxItems
                                        
                };

                resp = client.SimulateCustomPolicy(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.EvaluationResults)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.Marker));
        }
    }
}