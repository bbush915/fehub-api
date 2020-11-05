//-----------------------------------------------------------------------------
// <copyright file="GqlArtist.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlArtist : ObjectGraphType<Artist>
    {
        public GqlArtist()
        {
            this.Name = nameof(Artist);
            this.Description = DisplayHelpers.GetDescription<Artist>();

            this
                .Field(nameof(Artist.Company), x => x.Company, nullable: true)
                .Description(DisplayHelpers.GetDescription<Artist>(nameof(Artist.Company)));

            this
                .Field(nameof(Artist.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType))
                .Description(DisplayHelpers.GetDescription<Artist>(nameof(Artist.CreatedAt)));

            this
                .Field(nameof(Artist.CreatedBy), x => x.CreatedBy)
                .Description(DisplayHelpers.GetDescription<Artist>(nameof(Artist.CreatedBy)));

            this
                .Field(nameof(Artist.Id), x => x.Id)
                .Description(DisplayHelpers.GetDescription<Artist>(nameof(Artist.Id)));

            this
                .Field(nameof(Artist.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType))
                .Description(DisplayHelpers.GetDescription<Artist>(nameof(Artist.ModifiedAt)));

            this
                .Field(nameof(Artist.ModifiedBy), x => x.ModifiedBy)
                .Description(DisplayHelpers.GetDescription<Artist>(nameof(Artist.ModifiedBy)));

            this
                .Field(nameof(Artist.Name), x => x.Name)
                .Description(DisplayHelpers.GetDescription<Artist>(nameof(Artist.Name)));

            this
                .Field(nameof(Artist.NameKanji), x => x.NameKanji, nullable: true)
                .Description(DisplayHelpers.GetDescription<Artist>(nameof(Artist.NameKanji)));

            this
                .Field(nameof(Artist.Version), x => x.Version)
                .Description(DisplayHelpers.GetDescription<Artist>(nameof(Artist.Version)));
        }
    }
}
