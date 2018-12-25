using Amazon;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class CloudFormationListImportsOperation : Operation
    {
        public override string Name => "ListImports";

        public override string Description => "Lists all stacks that are importing an exported output value. To modify or remove an exported output value, first use this action to see which stacks are using it. To see the exported output values in your account, see ListExports.  For more information about importing an exported output value, see the  Fn::ImportValue  function. ";
 
        public override string RequestURI => "";

        public override string Method => "";

        public override string ServiceName => "CloudFormation";

        public override string ServiceID => "CloudFormation";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonCloudFormationClient client = new AmazonCloudFormationClient(creds, region);
            Response resp = new Response();
            do
            {
                ListImportsRequest req = new ListImportsRequest
                {
                    NextToken = resp.NextToken
                                        
                };

                resp = client.ListImports(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Imports)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}