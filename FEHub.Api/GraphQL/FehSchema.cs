using System;

using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace FEHub.Api.GraphQL;

internal sealed class FehSchema : Schema
{
    public FehSchema(IServiceProvider serviceProvider)
    : base(serviceProvider)
    {
        this.Query = (IObjectGraphType)serviceProvider.GetRequiredService<GqlQuery>();
    }
}
