using BasicShopDemo.Api.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;

namespace BasicShopDemo.Api.GraphQL.Schemas
{
    public class ProviderSchema : Schema
    {
        public ProviderSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ProviderQuery>();
        }
    }
}
