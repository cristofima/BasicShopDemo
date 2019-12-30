using GraphQL.Types;

namespace BasicShopDemo.Api.GraphQL.Types.InputTypes
{
    /// <summary>
    /// Provider input type
    /// </summary>
    public class ProviderInputType : InputObjectGraphType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BasicShopDemo.Api.GraphQL.Types.InputTypes.ProviderInputType"/> class.
        /// </summary>
        public ProviderInputType()
        {
            Name = "ProviderInput";

            Field<IdGraphType>("Id");
            Field<NonNullGraphType<StringGraphType>>("RUC");
            Field<NonNullGraphType<StringGraphType>>("BusinessName");
            Field<NonNullGraphType<StringGraphType>>("Address");
            Field<StringGraphType>("Email");
            Field<StringGraphType>("Phone");
            Field<StringGraphType>("CellPhone");
            Field<StringGraphType>("WebSite");
            Field<BooleanGraphType>("Status");
        }
    }
}
