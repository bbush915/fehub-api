using FEHub.Api.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL;

internal sealed class GqlEnumerationValue : ObjectGraphType<EnumerationValue>
{
    public GqlEnumerationValue()
    {
        this.Name = nameof(EnumerationValue);
        this.Description = "An enumerable value.";

        this.Field(nameof(EnumerationValue.Description), x => x.Description);
        this.Field(nameof(EnumerationValue.DisplayValue), x => x.DisplayValue);
        this.Field(nameof(EnumerationValue.Name), x => x.Name);
        this.Field(nameof(EnumerationValue.Value), x => x.Value);
    }
}
