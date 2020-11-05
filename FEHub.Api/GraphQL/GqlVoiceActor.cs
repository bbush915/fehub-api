//-----------------------------------------------------------------------------
// <copyright file="GqlVoiceActor.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlVoiceActor : ObjectGraphType<VoiceActor>
    {
        public GqlVoiceActor()
        {
            this.Name = nameof(VoiceActor);
            this.Description = DisplayHelpers.GetDescription<VoiceActor>();

            this
                .Field(nameof(VoiceActor.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType))
                .Description(DisplayHelpers.GetDescription<VoiceActor>(nameof(VoiceActor.CreatedAt)));

            this
                .Field(nameof(VoiceActor.CreatedBy), x => x.CreatedBy)
                .Description(DisplayHelpers.GetDescription<VoiceActor>(nameof(VoiceActor.CreatedBy)));

            this
                .Field(nameof(VoiceActor.Id), x => x.Id)
                .Description(DisplayHelpers.GetDescription<VoiceActor>(nameof(VoiceActor.Id)));

            this
                .Field(nameof(VoiceActor.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType))
                .Description(DisplayHelpers.GetDescription<VoiceActor>(nameof(VoiceActor.ModifiedAt)));

            this
                .Field(nameof(VoiceActor.ModifiedBy), x => x.ModifiedBy)
                .Description(DisplayHelpers.GetDescription<VoiceActor>(nameof(VoiceActor.ModifiedBy)));

            this
                .Field(nameof(VoiceActor.Name), x => x.Name)
                .Description(DisplayHelpers.GetDescription<VoiceActor>(nameof(VoiceActor.Name)));

            this
                .Field(nameof(VoiceActor.NameKanji), x => x.NameKanji, nullable: true)
                .Description(DisplayHelpers.GetDescription<VoiceActor>(nameof(VoiceActor.NameKanji)));

            this
                .Field(nameof(VoiceActor.Version), x => x.Version)
                .Description(DisplayHelpers.GetDescription<VoiceActor>(nameof(VoiceActor.Version)));
        }
    }
}
