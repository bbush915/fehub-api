//-----------------------------------------------------------------------------
// <copyright file="GqlHero.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using FEHub.Api.Services;
using FEHub.Entity;
using FEHub.Entity.Models;

using GraphQL.DataLoader;
using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlHero : ObjectGraphType<Hero>
    {
        #region Constructors
        public GqlHero(FehContextFactory dbContextFactory, IDataLoaderContextAccessor accessor)
        {
            this.Name = nameof(Hero);

            this.Field(nameof(Hero.AdditionDate), x => x.AdditionDate);
            this.Field(nameof(Hero.ArtistId), x => x.ArtistId);
            this.Field(nameof(Hero.AttackGrowthRate), x => x.AttackGrowthRate);
            this.Field(nameof(Hero.BaseAttack), x => x.BaseAttack);
            this.Field(nameof(Hero.BaseDefense), x => x.BaseDefense);
            this.Field(nameof(Hero.BaseHitPoints), x => x.BaseHitPoints);
            this.Field(nameof(Hero.BaseResistance), x => x.BaseResistance);
            this.Field(nameof(Hero.BaseSpeed), x => x.BaseSpeed);
            this.Field(nameof(Hero.BVID).ToLowerInvariant(), x => x.BVID);
            this.Field(nameof(Hero.Color), x => (int)x.Color);
            this.Field(nameof(Hero.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(Hero.CreatedBy), x => x.CreatedBy);
            this.Field(nameof(Hero.DefenseGrowthRate), x => x.DefenseGrowthRate);
            this.Field(nameof(Hero.Description), x => x.Description);
            this.Field(nameof(Hero.Element), x => (int?)x.Element, nullable: true);
            this.Field(nameof(Hero.Gender), x => (int)x.Gender);
            this.Field(nameof(Hero.HitPointsGrowthRate), x => x.HitPointsGrowthRate);
            this.Field(nameof(Hero.Id), x => x.Id);
            this.Field(nameof(Hero.IsDuoHero), x => x.IsDuoHero);
            this.Field(nameof(Hero.IsLegendaryHero), x => x.IsLegendaryHero);
            this.Field(nameof(Hero.IsMythicHero), x => x.IsMythicHero);
            this.Field(nameof(Hero.IsResplendentHero), x => x.IsResplendentHero);
            this.Field(nameof(Hero.LegendaryHeroBoostType), x => (int?)x.LegendaryHeroBoostType, nullable: true);
            this.Field(nameof(Hero.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(Hero.ModifiedBy), x => x.ModifiedBy);
            this.Field(nameof(Hero.MovementType), x => (int)x.MovementType);
            this.Field(nameof(Hero.MythicHeroBoostType), x => (int?)x.MythicHeroBoostType, nullable: true);
            this.Field(nameof(Hero.Name), x => x.Name);
            this.Field(nameof(Hero.Origin), x => x.Origin);
            this.Field(nameof(Hero.ReleaseDate), x => x.ReleaseDate);
            this.Field(nameof(Hero.ResistanceGrowthRate), x => x.ResistanceGrowthRate);
            this.Field(nameof(Hero.SpeedGrowthRate), x => x.SpeedGrowthRate);
            this.Field(nameof(Hero.Tag), x => x.Tag);
            this.Field(nameof(Hero.Title), x => x.Title);
            this.Field(nameof(Hero.Version), x => x.Version);
            this.Field(nameof(Hero.Weapon), x => (int)x.Weapon);

            /* Data Loader */

            this
                .Field<GqlArtist, Artist>()
                .Name(nameof(Hero.Artist))
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new ArtistService(dbContextFactory.CreateDbContext());

                        var loader = accessor.Context.GetOrAddBatchLoader<int, Artist>(
                            $"{nameof(Artist)}_{nameof(ArtistService.GetByIdsAsync)}",
                            service.GetByIdsAsync
                        );

                        return loader.LoadAsync(context.Source.ArtistId);
                    }
                );

            this
                .Field<ListGraphType<GqlHeroSkill>, IEnumerable<HeroSkill>>()
                .Name(nameof(Hero.HeroSkills))
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new HeroSkillService(dbContextFactory.CreateDbContext());

                        var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, HeroSkill>(
                            $"{nameof(HeroSkill)}_{nameof(HeroSkillService.GetByHeroIdsAsync)}",
                            service.GetByHeroIdsAsync
                        );

                        return loader.LoadAsync(context.Source.Id);
                    }
                );

            this
                .Field<ListGraphType<GqlHeroVoiceActor>, IEnumerable<HeroVoiceActor>>()
                .Name(nameof(Hero.HeroVoiceActors))
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new HeroVoiceActorService(dbContextFactory.CreateDbContext());

                        var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, HeroVoiceActor>(
                            $"{nameof(HeroVoiceActor)}_{nameof(HeroVoiceActorService.GetByHeroIdsAsync)}",
                            service.GetByHeroIdsAsync
                        );

                        return loader.LoadAsync(context.Source.Id);
                    }
                );
        }
        #endregion
    }
}
