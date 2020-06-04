//-----------------------------------------------------------------------------
// <copyright file="GqlSkill.cs">
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
    internal sealed class GqlSkill : ObjectGraphType<Skill>
    {
        #region Constructors
        public GqlSkill(FehContextFactory dbContextFactory, IDataLoaderContextAccessor accessor)
        {
            this.Name = nameof(Skill);

            this.Field(nameof(Skill.AttackModifier), x => x.AttackModifier, nullable: true);
            this.Field(nameof(Skill.Cooldown), x => x.Cooldown, nullable: true);
            this.Field(nameof(Skill.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(Skill.CreatedBy), x => x.CreatedBy);
            this.Field(nameof(Skill.DefenseModifier), x => x.DefenseModifier, nullable: true);
            this.Field(nameof(Skill.Description), x => x.Description, nullable: true);
            this.Field(nameof(Skill.GroupName), x => x.GroupName);
            this.Field(nameof(Skill.HitPointsModifier), x => x.HitPointsModifier, nullable: true);
            this.Field(nameof(Skill.Id), x => x.Id);
            this.Field(nameof(Skill.IsAvailableAsSacredSeal), x => x.IsAvailableAsSacredSeal);
            this.Field(nameof(Skill.IsExclusive), x => x.IsExclusive);
            this.Field(nameof(Skill.Might), x => x.Might, nullable: true);
            this.Field(nameof(Skill.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType));
            this.Field(nameof(Skill.ModifiedBy), x => x.ModifiedBy);
            this.Field(nameof(Skill.Name), x => x.Name);
            this.Field(nameof(Skill.Range), x => x.Range, nullable: true);
            this.Field(nameof(Skill.ResistanceModifier), x => x.ResistanceModifier, nullable: true);
            this.Field(nameof(Skill.SkillPoints), x => x.SkillPoints);
            this.Field(nameof(Skill.SkillType), x => (int)x.SkillType);
            this.Field(nameof(Skill.SpeedModifier), x => x.SpeedModifier, nullable: true);
            this.Field(nameof(Skill.Tag), x => x.Tag);
            this.Field(nameof(Skill.Version), x => x.Version);
            this.Field(nameof(Skill.WeaponRefineType), x => (int?)x.WeaponRefineType, nullable: true);

            /* Data Loader */

            this
                .Field<ListGraphType<GqlSkillMovementType>, IEnumerable<SkillMovementType>>()
                .Name(nameof(Skill.SkillMovementTypes))
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new SkillMovementTypeService(dbContextFactory.CreateDbContext());

                        var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, SkillMovementType>(
                            $"{nameof(SkillMovementType)}_{nameof(SkillMovementTypeService.GetBySkillIdsAsync)}",
                            service.GetBySkillIdsAsync
                        );

                        return loader.LoadAsync(context.Source.Id);
                    }
                );

            this
                .Field<ListGraphType<GqlSkillWeaponEffectiveness>, IEnumerable<SkillWeaponEffectiveness>>()
                .Name(nameof(Skill.SkillWeaponEffectivenesses))
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new SkillWeaponEffectivenessService(dbContextFactory.CreateDbContext());

                        var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, SkillWeaponEffectiveness>(
                            $"{nameof(SkillWeaponEffectiveness)}_{nameof(SkillWeaponEffectivenessService.GetBySkillIdsAsync)}",
                            service.GetBySkillIdsAsync
                        );

                        return loader.LoadAsync(context.Source.Id);
                    }
                );

            this
                .Field<ListGraphType<GqlSkillWeaponType>, IEnumerable<SkillWeaponType>>()
                .Name(nameof(Skill.SkillWeaponTypes))
                .ResolveAsync(
                    (context) =>
                    {
                        var service = new SkillWeaponTypeService(dbContextFactory.CreateDbContext());

                        var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, SkillWeaponType>(
                            $"{nameof(SkillWeaponType)}_{nameof(SkillWeaponTypeService.GetBySkillIdsAsync)}",
                            service.GetBySkillIdsAsync
                        );

                        return loader.LoadAsync(context.Source.Id);
                    }
                );
        }
        #endregion
    }
}
