//-----------------------------------------------------------------------------
// <copyright file="GqlHeroSkill.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;

using FEHub.Api.Services;
using FEHub.Entity;
using FEHub.Entity.Models;

using GraphQL.DataLoader;
using GraphQL.Types;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlHeroSkill : ObjectGraphType<HeroSkill>
    {
        #region Constructors
        public GqlHeroSkill(FehContextFactory dbContextFactory, IDataLoaderContextAccessor accessor)
        {
            this.Name = nameof(HeroSkill);

            this.Field(nameof(HeroSkill.DefaultRarity), x => x.DefaultRarity, nullable: true);
            this.Field(nameof(HeroSkill.HeroId), x => x.HeroId);
            this.Field(nameof(HeroSkill.Id), x => x.Id);
            this.Field(nameof(HeroSkill.SkillId), x => x.SkillId);
            this.Field(nameof(HeroSkill.SkillPosition), x => x.SkillPosition);
            this.Field(nameof(HeroSkill.UnlockRarity), x => x.UnlockRarity);

            /* Data Loader */

            this
                .Field<GqlSkill, Skill>()
                .Name(nameof(HeroSkill.Skill))
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new SkillService(dbContextFactory.CreateDbContext());

                        var loader = accessor.Context.GetOrAddBatchLoader<Guid, Skill>(
                            nameof(SkillService.GetByIdsAsync),
                            service.GetByIdsAsync
                        );

                        return loader.LoadAsync(context.Source.SkillId);
                    }
                );
        }
        #endregion
    }
}
