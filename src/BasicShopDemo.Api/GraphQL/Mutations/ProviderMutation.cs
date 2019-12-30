using BasicShopDemo.Api.DAO;
using BasicShopDemo.Api.GraphQL.Types;
using BasicShopDemo.Api.GraphQL.Types.InputTypes;
using BasicShopDemo.Api.Models;
using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;

namespace BasicShopDemo.Api.GraphQL.Mutations
{
    public class ProviderMutation : ObjectGraphType
    {
        public ProviderMutation(BasicShopContext caducaContext)
        {
            var providerDAO = new ProviderDAO(caducaContext);

            FieldAsync<ProviderType>
                (
                    "createProvider",
                    arguments: new QueryArguments(
                        new QueryArgument
                        <NonNullGraphType<ProviderInputType>>
                        { Name = "provider" }
                    ),
                    resolve: async context =>
                    {
                        var provider = context.GetArgument<Provider>("provider");
                        var isCorrect = await providerDAO.AddAsync(provider);
                        if (isCorrect)
                        {
                            return provider;
                        }
                        else
                        {
                            context.Errors.Add(new ExecutionError($"The provider could not be saved"));
                            return null;
                        }
                    }
                );

            FieldAsync<StringGraphType>(
                    "deleteProvider",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                    resolve: async context =>
                    {
                        var id = context.GetArgument<int>("id");
                        var isCorrect = await providerDAO.DeleteAsync(id);
                        if (isCorrect)
                        {
                            return $"The provider with id {id} was deleted";
                        }

                        if (providerDAO.customError != null && providerDAO.customError.Errors != null)
                        {
                            var errors = providerDAO.customError.Errors;

                            foreach (KeyValuePair<string, List<string>> entry in errors)
                            {
                                var list = entry.Value;

                                foreach (string message in list)
                                {
                                    context.Errors.Add(new ExecutionError(message));
                                }
                            }
                        }
                        else
                        {
                            return $"The provider with id {id} could not be deleted";
                        }

                        return null;
                    }
                );

            FieldAsync<ProviderType>(
                    "updateProvider",
                      arguments: new QueryArguments(
                        new QueryArgument
                        <NonNullGraphType<ProviderInputType>>
                        { Name = "provider" },
                        new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                      resolve: async context =>
                      {
                          var provider = context.GetArgument<Provider>("provider");
                          var id = context.GetArgument<int>("id");

                          provider.Id = id;

                          var isCorrect = await providerDAO.UpdateAsync(provider);
                          if (isCorrect)
                          {
                              return provider;
                          }

                          if (providerDAO.customError != null && providerDAO.customError.Errors != null)
                          {
                              var errors = providerDAO.customError.Errors;

                              foreach (KeyValuePair<string, List<string>> entry in errors)
                              {
                                  var list = entry.Value;

                                  foreach (string message in list)
                                  {
                                      context.Errors.Add(new ExecutionError(message));
                                  }
                              }
                          }
                          else
                          {
                              return $"The provider with id {id} could not be updated";
                          }

                          return null;
                      }
                );
        }
    }
}
