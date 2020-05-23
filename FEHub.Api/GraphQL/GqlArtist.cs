//-----------------------------------------------------------------------------
// <copyright file="GqlArtist.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlArtist : ObjectGraphType<Artist>
    {
        #region Constructors
        public GqlArtist()
        {
            this.Name = nameof(Artist);

            this.Field(nameof(Artist.Company), x => x.Company, nullable: true);
            this.Field(nameof(Artist.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(Artist.CreatedBy), x => x.CreatedBy);
            this.Field(nameof(Artist.Id), x => x.Id);
            this.Field(nameof(Artist.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(Artist.ModifiedBy), x => x.ModifiedBy);
            this.Field(nameof(Artist.Name), x => x.Name);
            this.Field(nameof(Artist.NameKanji), x => x.NameKanji, nullable: true);
            this.Field(nameof(Artist.Version), x => x.Version);
        }
        #endregion
    }
}
