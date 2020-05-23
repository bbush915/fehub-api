//-----------------------------------------------------------------------------
// <copyright file="GqlItem.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlItem : ObjectGraphType<Item>
    {
        #region Constructors
        public GqlItem()
        {
            this.Name = nameof(Item);

            this.Field(nameof(Item.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(Item.CreatedBy), x => x.CreatedBy);
            this.Field(nameof(Item.Description), x => x.Description);
            this.Field(nameof(Item.Id), x => x.Id);
            this.Field(nameof(Item.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(Item.ModifiedBy), x => x.ModifiedBy);
            this.Field(nameof(Item.Name), x => x.Name);
            this.Field(nameof(Item.Version), x => x.Version);
        }
        #endregion
    }
}
