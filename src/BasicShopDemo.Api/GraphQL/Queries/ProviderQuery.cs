using BasicShopDemo.Api.DAO;
using BasicShopDemo.Api.GraphQL.Types;
using BasicShopDemo.Api.Models;
using GraphQL;
using GraphQL.Types;

namespace BasicShopDemo.Api.GraphQL.Queries
{
    public class ProviderQuery : ObjectGraphType
    {
        public ProviderQuery(BasicShopContext context)
        {
            var providerDAO = new ProviderDAO(context);

            this.FieldAsync<ListGraphType<ProviderType>>("providers", resolve: async context =>
            {
                return await providerDAO.GetAllAsync();
            });

            this.FieldAsync<ProviderType>("findProvider", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
              ), resolve: async context =>
              {
                  var id = context.GetArgument<int>("id");
                  var provider = await providerDAO.GetByIdAsync(id);
                  if (provider != null)
                  {
                      return provider;
                  }

                  context.Errors.Add(new ExecutionError($"There is not a Provider with id {id}"));
                  return null;
              });
        }
    }
}
