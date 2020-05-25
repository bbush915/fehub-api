//-----------------------------------------------------------------------------
// <copyright file="GqlHeroVoiceActor.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using FEHub.Api.Services;
using FEHub.Entity;
using FEHub.Entity.Models;

using GraphQL.DataLoader;
using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlHeroVoiceActor : ObjectGraphType<HeroVoiceActor>
    {
        #region Constructors
        public GqlHeroVoiceActor(FehContextFactory dbContextFactory, IDataLoaderContextAccessor accessor)
        {
            this.Name = nameof(HeroVoiceActor);

            this.Field(nameof(HeroVoiceActor.HeroId), x => x.HeroId);
            this.Field(nameof(HeroVoiceActor.Id), x => x.Id);
            this.Field(nameof(HeroVoiceActor.Language), x => (int)x.Language);
            this.Field(nameof(HeroVoiceActor.Sort), x => x.Sort);
            this.Field(nameof(HeroVoiceActor.VoiceActorId), x => x.VoiceActorId);

            /* Data Loader */

            this
                .Field<GqlVoiceActor, VoiceActor>()
                .Name(nameof(HeroVoiceActor.VoiceActor))
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new VoiceActorService(dbContextFactory.CreateDbContext());

                        var loader = accessor.Context.GetOrAddBatchLoader<int, VoiceActor>(
                            $"{nameof(VoiceActor)}_{nameof(VoiceActorService.GetByIdsAsync)}",
                            service.GetByIdsAsync
                        );

                        return loader.LoadAsync(context.Source.VoiceActorId);
                    }
                );
        }
        #endregion
    }
}
