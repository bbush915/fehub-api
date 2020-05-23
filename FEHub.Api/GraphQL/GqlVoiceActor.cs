//-----------------------------------------------------------------------------
// <copyright file="GqlVoiceActor.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Entity.Models;

using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlVoiceActor : ObjectGraphType<VoiceActor>
    {
        #region Constructors
        public GqlVoiceActor()
        {
            this.Name = nameof(VoiceActor);

            this.Field(nameof(VoiceActor.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(VoiceActor.CreatedBy), x => x.CreatedBy);
            this.Field(nameof(VoiceActor.Id), x => x.Id);
            this.Field(nameof(VoiceActor.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(VoiceActor.ModifiedBy), x => x.ModifiedBy);
            this.Field(nameof(VoiceActor.Name), x => x.Name);
            this.Field(nameof(VoiceActor.NameKanji), x => x.NameKanji, nullable: true);
            this.Field(nameof(VoiceActor.Version), x => x.Version);
        }
        #endregion
    }
}
