//-----------------------------------------------------------------------------
// <copyright file="GqlAccessory.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlAccessory : ObjectGraphType<Accessory>
    {
        #region Constructors
        public GqlAccessory()
        {
            this.Name = nameof(Accessory);

            this.Field(nameof(Accessory.AccessoryType), x => (int)x.AccessoryType);
            this.Field(nameof(Accessory.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(Accessory.CreatedBy), x => x.CreatedBy);
            this.Field(nameof(Accessory.Description), x => x.Description);
            this.Field(nameof(Accessory.Id), x => x.Id);
            this.Field(nameof(Accessory.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(Accessory.ModifiedBy), x => x.ModifiedBy);
            this.Field(nameof(Accessory.Name), x => x.Name);
            this.Field(nameof(Accessory.Tag), x => x.Tag);
            this.Field(nameof(Accessory.Version), x => x.Version);
        }
        #endregion
    }
}
