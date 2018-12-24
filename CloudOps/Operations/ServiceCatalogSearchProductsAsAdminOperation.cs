using Amazon;
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;
using Amazon.Runtime;

namespace CloudOps.Operations
{
    public class ServiceCatalogSearchProductsAsAdminOperation : Operation
    {
        public override string Name => "SearchProductsAsAdmin";

        public override string Description => "Gets information about the products for the specified portfolio or all products.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ServiceCatalog";

        public override string ServiceID => "Service Catalog";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonServiceCatalogClient client = new AmazonServiceCatalogClient(creds, region);
            SearchProductsAsAdminOutput resp = new SearchProductsAsAdminOutput();
            do
            {
                SearchProductsAsAdminInput req = new SearchProductsAsAdminInput
                {
                    PageToken = resp.NextPageToken,
                    PageSize = maxItems
                };
                resp = client.SearchProductsAsAdmin(req);
                CheckError(resp.HttpStatusCode, "&lt;nil&gt;");                

                foreach (var obj in resp.&lt;nil&gt;)
                {
                    AddObject(obj);
                }
            }
            while (!string.IsNullOrEmpty(resp.NextPageToken));
        }
    }
}