using BasicShopDemo.Api.Models;
using GraphQL.Types;

namespace BasicShopDemo.Api.GraphQL.Types
{
    public class ProviderType : ObjectGraphType<Provider>
    {
        public ProviderType()
        {
            Name = "Provider";

            Field(c => c.Id).Description("Id");
            Field(c => c.RUC).Description("RUC");
            Field(c => c.BusinessName).Description("Business Name");
            Field(c => c.Address).Description("Address");
            Field(c => c.Email, nullable: true).Description("Email");
            Field(c => c.Phone, nullable: true).Description("Phone");
            Field(c => c.CellPhone, nullable: true).Description("CellPhone");
            Field(c => c.WebSite, nullable: true).Description("WebSite");
            Field(c => c.Status, nullable: true).Description("Status");
        }
    }
}
