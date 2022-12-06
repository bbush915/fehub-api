using System;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace FEHub.Api.GraphQL;

internal sealed class GqlHeroSkill : ObjectGraphType<HeroSkill>
{
    public GqlHeroSkill(IDataLoaderContextAccessor accessor)
    {
        this.Name = nameof(HeroSkill);
        this.Description = DisplayHelpers.GetDescription<HeroSkill>();

        this
            .Field(nameof(HeroSkill.DefaultRarity), x => x.DefaultRarity, nullable: true)
            .Description(DisplayHelpers.GetDescription<HeroSkill>(nameof(HeroSkill.DefaultRarity)));

        this
            .Field(nameof(HeroSkill.HeroId), x => x.HeroId)
            .Description(DisplayHelpers.GetDescription<HeroSkill>(nameof(HeroSkill.HeroId)));

        this
            .Field(nameof(HeroSkill.Id), x => x.Id)
            .Description(DisplayHelpers.GetDescription<HeroSkill>(nameof(HeroSkill.Id)));

        this
            .Field(nameof(HeroSkill.SkillId), x => x.SkillId)
            .Description(DisplayHelpers.GetDescription<HeroSkill>(nameof(HeroSkill.SkillId)));

        this
            .Field(nameof(HeroSkill.SkillPosition), x => x.SkillPosition)
            .Description(DisplayHelpers.GetDescription<HeroSkill>(nameof(HeroSkill.SkillPosition)));

        this
            .Field(nameof(HeroSkill.UnlockRarity), x => x.UnlockRarity)
            .Description(DisplayHelpers.GetDescription<HeroSkill>(nameof(HeroSkill.UnlockRarity)));

        /* Data Loader */

        this
            .Field<GqlSkill, Skill>(nameof(HeroSkill.Skill))
            .Description(DisplayHelpers.GetDescription<HeroSkill>(nameof(HeroSkill.Skill)))
            .ResolveAsync(
                (context) =>
                {
                    var skillService = context.RequestServices.GetRequiredService<ISkillService>();

                    var dataLoader = accessor.Context.GetOrAddBatchLoader<Guid, Skill>(
                        $"{nameof(Skill)}_{nameof(ISkillService.GetByIdsAsync)}",
                        skillService.GetByIdsAsync
                    );

                    return dataLoader.LoadAsync(context.Source.SkillId);
                }
            );
    }
}
