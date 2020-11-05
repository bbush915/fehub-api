//-----------------------------------------------------------------------------
// <copyright file="GqlHero.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Common.Enumerations;
using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL.Utilities;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlHero : ObjectGraphType<Hero>
    {
        public GqlHero(IDataLoaderContextAccessor accessor)
        {
            this.Name = nameof(Hero);
            this.Description = DisplayHelpers.GetDescription<Hero>();

            this
                .Field(nameof(Hero.AdditionDate), x => x.AdditionDate)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.AdditionDate)));

            this
                .Field(nameof(Hero.ArtistId), x => x.ArtistId)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.ArtistId)));

            this
                .Field(nameof(Hero.AttackGrowthRate), x => x.AttackGrowthRate)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.AttackGrowthRate)));

            this
                .Field(nameof(Hero.BaseAttack), x => x.BaseAttack)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.BaseAttack)));

            this
                .Field(nameof(Hero.BaseDefense), x => x.BaseDefense)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.BaseDefense)));

            this
                .Field(nameof(Hero.BaseHitPoints), x => x.BaseHitPoints)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.BaseHitPoints)));

            this
                .Field(nameof(Hero.BaseResistance), x => x.BaseResistance)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.BaseResistance)));

            this
                .Field(nameof(Hero.BaseSpeed), x => x.BaseSpeed)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.BaseSpeed)));

            this
                .Field(nameof(Hero.BVID).ToLowerInvariant(), x => x.BVID)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.BVID)));

            this
                .Field(nameof(Hero.Color), x => (int)x.Color)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Color)));

            this
                .Field(nameof(Hero.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType))
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.CreatedAt)));

            this
                .Field(nameof(Hero.CreatedBy), x => x.CreatedBy)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.CreatedBy)));

            this
                .Field(nameof(Hero.DefenseGrowthRate), x => x.DefenseGrowthRate)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.DefenseGrowthRate)));

            this
                .Field(nameof(Hero.Description), x => x.Description)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Description)));

            this
                .Field(nameof(Hero.Element), x => (int?)x.Element, nullable: true)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Element)));

            this
                .Field(nameof(Hero.Gender), x => (int)x.Gender)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Gender)));

            this
                .Field(nameof(Hero.HitPointsGrowthRate), x => x.HitPointsGrowthRate)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.HitPointsGrowthRate)));

            this
                .Field(nameof(Hero.Id), x => x.Id)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Id)));

            this
                .Field(nameof(Hero.IsDuoHero), x => x.IsDuoHero)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.IsDuoHero)));

            this
                .Field(nameof(Hero.IsLegendaryHero), x => x.IsLegendaryHero)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.IsLegendaryHero)));

            this
                .Field(nameof(Hero.IsMythicHero), x => x.IsMythicHero)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.IsMythicHero)));

            this
                .Field(nameof(Hero.IsResplendentHero), x => x.IsResplendentHero)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.IsResplendentHero)));

            this
                .Field(nameof(Hero.LegendaryHeroBoostType), x => (int?)x.LegendaryHeroBoostType, nullable: true)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.LegendaryHeroBoostType)));

            this
                .Field(nameof(Hero.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType))
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.ModifiedAt)));

            this
                .Field(nameof(Hero.ModifiedBy), x => x.ModifiedBy)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.ModifiedBy)));

            this
                .Field(nameof(Hero.MovementType), x => (int)x.MovementType)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.MovementType)));

            this
                .Field(nameof(Hero.MythicHeroBoostType), x => (int?)x.MythicHeroBoostType, nullable: true)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.MythicHeroBoostType)));

            this
                .Field(nameof(Hero.Name), x => x.Name)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Name)));

            this
                .Field(nameof(Hero.Origin), x => x.Origin)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Origin)));

            this
                .Field(nameof(Hero.ReleaseDate), x => x.ReleaseDate)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.ReleaseDate)));

            this
                .Field(nameof(Hero.ResistanceGrowthRate), x => x.ResistanceGrowthRate)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.ResistanceGrowthRate)));

            this
                .Field(nameof(Hero.SpeedGrowthRate), x => x.SpeedGrowthRate)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.SpeedGrowthRate)));

            this
                .Field(nameof(Hero.Tag), x => x.Tag)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Tag)));

            this
                .Field(nameof(Hero.Title), x => x.Title)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Title)));

            this
                .Field(nameof(Hero.Version), x => x.Version)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Version)));

            this
                .Field(nameof(Hero.Weapon), x => (int)x.Weapon)
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Weapon)));

            /* Data Loader */

            this
                .Field<GqlArtist, Artist>()
                .Name(nameof(Hero.Artist))
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.Artist)))
                .ResolveAsync(
                    (context) =>
                    {
                        var artistService = context.RequestServices.GetRequiredService<IArtistService>();

                        var dataLoader = accessor.Context.GetOrAddBatchLoader<int, Artist>(
                            $"{nameof(Artist)}_{nameof(IArtistService.GetByIdsAsync)}",
                            artistService.GetByIdsAsync
                        );

                        return dataLoader.LoadAsync(context.Source.ArtistId);
                    }
                );

            this
                .Field<ListGraphType<GqlHeroSkill>, IEnumerable<HeroSkill>>()
                .Name(nameof(Hero.HeroSkills))
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.HeroSkills)))
                .ResolveAsync(
                    (context) =>
                    {
                        var heroSkillService = context.RequestServices.GetRequiredService<IHeroSkillService>();

                        var dataLoader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, HeroSkill>(
                            $"{nameof(HeroSkill)}_{nameof(IHeroSkillService.GetByHeroIdsAsync)}",
                            heroSkillService.GetByHeroIdsAsync
                        );

                        return dataLoader.LoadAsync(context.Source.Id);
                    }
                );

            this
                .Field<ListGraphType<GqlHeroVoiceActor>, IEnumerable<HeroVoiceActor>>()
                .Name(nameof(Hero.HeroVoiceActors))
                .Description(DisplayHelpers.GetDescription<Hero>(nameof(Hero.HeroVoiceActors)))
                .Argument<NonNullGraphType<IntGraphType>>("language")
                .ResolveAsync(
                    (context) =>
                    {
                        var heroVoiceActorService = context.RequestServices.GetRequiredService<IHeroVoiceActorService>();

                        var language = (Languages)context.GetArgument<int>("language");

                        var dataLoader = accessor.Context.GetOrAddCollectionBatchLoader(
                            $"{nameof(HeroVoiceActor)}_{nameof(IHeroVoiceActorService.GetByHeroIdsAsync)}",
                            heroVoiceActorService.GetByHeroIdsAsync(language)
                        );

                        return dataLoader.LoadAsync(context.Source.Id);
                    }
                );
        }
    }
}
