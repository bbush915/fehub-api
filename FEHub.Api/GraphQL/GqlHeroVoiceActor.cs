using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace FEHub.Api.GraphQL;

internal sealed class GqlHeroVoiceActor : ObjectGraphType<HeroVoiceActor>
{
    public GqlHeroVoiceActor(IDataLoaderContextAccessor accessor)
    {
        this.Name = nameof(HeroVoiceActor);
        this.Description = DisplayHelpers.GetDescription<HeroVoiceActor>();

        this
            .Field(nameof(HeroVoiceActor.HeroId), x => x.HeroId)
            .Description(DisplayHelpers.GetDescription<HeroVoiceActor>(nameof(HeroVoiceActor.HeroId)));

        this
            .Field(nameof(HeroVoiceActor.Id), x => x.Id)
            .Description(DisplayHelpers.GetDescription<HeroVoiceActor>(nameof(HeroVoiceActor.Id)));

        this
            .Field(nameof(HeroVoiceActor.Language), x => (int)x.Language)
            .Description(DisplayHelpers.GetDescription<HeroVoiceActor>(nameof(HeroVoiceActor.Language)));

        this
            .Field(nameof(HeroVoiceActor.Sort), x => x.Sort)
            .Description(DisplayHelpers.GetDescription<HeroVoiceActor>(nameof(HeroVoiceActor.Sort)));

        this
            .Field(nameof(HeroVoiceActor.VoiceActorId), x => x.VoiceActorId)
            .Description(DisplayHelpers.GetDescription<HeroVoiceActor>(nameof(HeroVoiceActor.VoiceActorId)));

        /* Data Loader */

        this
            .Field<GqlVoiceActor, VoiceActor>(nameof(HeroVoiceActor.VoiceActor))
            .Description(DisplayHelpers.GetDescription<HeroVoiceActor>(nameof(HeroVoiceActor.VoiceActor)))
            .ResolveAsync(
                (context) =>
                {
                    var voiceActorService = context.RequestServices.GetRequiredService<IVoiceActorService>();

                    var dataLoader = accessor.Context.GetOrAddBatchLoader<int, VoiceActor>(
                        $"{nameof(VoiceActor)}_{nameof(IVoiceActorService.GetByIdsAsync)}",
                        voiceActorService.GetByIdsAsync
                    );

                    return dataLoader.LoadAsync(context.Source.VoiceActorId);
                }
            );
    }
}
