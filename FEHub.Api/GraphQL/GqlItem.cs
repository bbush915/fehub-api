//-----------------------------------------------------------------------------
// <copyright file="GqlItem.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlItem : ObjectGraphType<Item>
    {
        public GqlItem()
        {
            this.Name = nameof(Item);
            this.Description = DisplayHelpers.GetDescription<Item>();

            this
                .Field(nameof(Item.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType))
                .Description(DisplayHelpers.GetDescription<Item>(nameof(Item.CreatedAt)));

            this
                .Field(nameof(Item.CreatedBy), x => x.CreatedBy)
                .Description(DisplayHelpers.GetDescription<Item>(nameof(Item.CreatedBy)));

            this
                .Field(nameof(Item.Description), x => x.Description)
                .Description(DisplayHelpers.GetDescription<Item>(nameof(Item.Description)));

            this
                .Field(nameof(Item.Id), x => x.Id)
                .Description(DisplayHelpers.GetDescription<Item>(nameof(Item.Id)));

            this
                .Field(nameof(Item.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType))
                .Description(DisplayHelpers.GetDescription<Item>(nameof(Item.ModifiedAt)));

            this
                .Field(nameof(Item.ModifiedBy), x => x.ModifiedBy)
                .Description(DisplayHelpers.GetDescription<Item>(nameof(Item.ModifiedBy)));

            this
                .Field(nameof(Item.Name), x => x.Name)
                .Description(DisplayHelpers.GetDescription<Item>(nameof(Item.Name)));

            this
                .Field(nameof(Item.Version), x => x.Version)
                .Description(DisplayHelpers.GetDescription<Item>(nameof(Item.Version)));
        }
    }
}
