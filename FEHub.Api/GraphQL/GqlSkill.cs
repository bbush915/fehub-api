//-----------------------------------------------------------------------------
// <copyright file="GqlSkill.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using FEHub.Api.Services.Interfaces;
using FEHub.Entity.Common.Helpers;
using FEHub.Entity.Models;

using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL.Utilities;

namespace FEHub.Api.GraphQL
{
    internal sealed class GqlSkill : ObjectGraphType<Skill>
    {
        public GqlSkill(IDataLoaderContextAccessor accessor)
        {
            this.Name = nameof(Skill);
            this.Description = DisplayHelpers.GetDescription<Skill>();

            this
                .Field(nameof(Skill.AttackModifier), x => x.AttackModifier, nullable: true)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.AttackModifier)));

            this
                .Field(nameof(Skill.Cooldown), x => x.Cooldown, nullable: true)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.Cooldown)));

            this
                .Field(nameof(Skill.CreatedAt), x => x.CreatedAt, type: typeof(DateTimeGraphType))
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.CreatedAt)));

            this
                .Field(nameof(Skill.CreatedBy), x => x.CreatedBy)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.CreatedBy)));

            this
                .Field(nameof(Skill.DefenseModifier), x => x.DefenseModifier, nullable: true)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.DefenseModifier)));

            this
                .Field(nameof(Skill.Description), x => x.Description, nullable: true)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.Description)));

            this
                .Field(nameof(Skill.GroupName), x => x.GroupName)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.GroupName)));

            this
                .Field(nameof(Skill.HitPointsModifier), x => x.HitPointsModifier, nullable: true)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.HitPointsModifier)));

            this
                .Field(nameof(Skill.Id), x => x.Id)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.Id)));

            this
                .Field(nameof(Skill.IsAvailableAsSacredSeal), x => x.IsAvailableAsSacredSeal)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.IsAvailableAsSacredSeal)));

            this
                .Field(nameof(Skill.IsExclusive), x => x.IsExclusive)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.IsExclusive)));

            this
                .Field(nameof(Skill.Might), x => x.Might, nullable: true)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.Might)));

            this
                .Field(nameof(Skill.ModifiedAt), x => x.ModifiedAt, type: typeof(DateTimeGraphType))
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.ModifiedAt)));

            this
                .Field(nameof(Skill.ModifiedBy), x => x.ModifiedBy)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.ModifiedBy)));

            this
                .Field(nameof(Skill.Name), x => x.Name)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.Name)));

            this
                .Field(nameof(Skill.Range), x => x.Range, nullable: true)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.Range)));

            this
                .Field(nameof(Skill.ResistanceModifier), x => x.ResistanceModifier, nullable: true)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.ResistanceModifier)));

            this
                .Field(nameof(Skill.SkillPoints), x => x.SkillPoints)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.SkillPoints)));

            this
                .Field(nameof(Skill.SkillType), x => (int)x.SkillType)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.SkillType)));

            this
                .Field(nameof(Skill.SpeedModifier), x => x.SpeedModifier, nullable: true)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.SpeedModifier)));

            this
                .Field(nameof(Skill.Tag), x => x.Tag)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.Tag)));

            this
                .Field(nameof(Skill.Version), x => x.Version)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.Version)));

            this
                .Field(nameof(Skill.WeaponRefineType), x => (int?)x.WeaponRefineType, nullable: true)
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.WeaponRefineType)));

            /* Data Loader */

            this
                .Field<ListGraphType<GqlSkillMovementType>, IEnumerable<SkillMovementType>>()
                .Name(nameof(Skill.SkillMovementTypes))
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.SkillMovementTypes)))
                .ResolveAsync(
                    (context) =>
                    {
                        var skillMovementTypeService = context.RequestServices.GetRequiredService<ISkillMovementTypeService>();

                        var dataLoader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, SkillMovementType>(
                            $"{nameof(SkillMovementType)}_{nameof(ISkillMovementTypeService.GetBySkillIdsAsync)}",
                            skillMovementTypeService.GetBySkillIdsAsync
                        );

                        return dataLoader.LoadAsync(context.Source.Id);
                    }
                );

            this
                .Field<ListGraphType<GqlSkillWeaponEffectiveness>, IEnumerable<SkillWeaponEffectiveness>>()
                .Name(nameof(Skill.SkillWeaponEffectivenesses))
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.SkillWeaponEffectivenesses)))
                .ResolveAsync(
                    (context) =>
                    {
                        var skillWeaponEffectivenessService = context.RequestServices.GetRequiredService<ISkillWeaponEffectivenessService>();

                        var dataLoader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, SkillWeaponEffectiveness>(
                            $"{nameof(SkillWeaponEffectiveness)}_{nameof(ISkillWeaponEffectivenessService.GetBySkillIdsAsync)}",
                            skillWeaponEffectivenessService.GetBySkillIdsAsync
                        );

                        return dataLoader.LoadAsync(context.Source.Id);
                    }
                );

            this
                .Field<ListGraphType<GqlSkillWeaponType>, IEnumerable<SkillWeaponType>>()
                .Name(nameof(Skill.SkillWeaponTypes))
                .Description(DisplayHelpers.GetDescription<Skill>(nameof(Skill.SkillWeaponTypes)))
                .ResolveAsync(
                    (context) =>
                    {
                        var skillWeaponTypeService = context.RequestServices.GetRequiredService<ISkillWeaponTypeService>();

                        var dataLoader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, SkillWeaponType>(
                            $"{nameof(SkillWeaponType)}_{nameof(ISkillWeaponTypeService.GetBySkillIdsAsync)}",
                            skillWeaponTypeService.GetBySkillIdsAsync
                        );

                        return dataLoader.LoadAsync(context.Source.Id);
                    }
                );
        }
    }
}
