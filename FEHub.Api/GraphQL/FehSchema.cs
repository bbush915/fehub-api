//-----------------------------------------------------------------------------
// <copyright file="FehSchema.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class FehSchema : Schema
    {
        public FehSchema(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
            this.Query = (IObjectGraphType)serviceProvider.GetService(typeof(GqlQuery));
        }
    }
}
